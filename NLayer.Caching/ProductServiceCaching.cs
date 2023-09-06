using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Caching
{
    public class ProductServiceCaching : IProductService //proxy dizayn pattern
    {
        private const string CacheProductKey = "productsCache";
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServiceCaching(IMemoryCache memoryCache, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
        {
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheProductKey, out _)) //out _ memoryde yer tutmaz
            {
                _memoryCache.Set(CacheProductKey, _productRepository.GetProductsWithCategoty().Result);
            }
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _productRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAll();
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _productRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAll();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            return Task.FromResult(_memoryCache.Get<List<Product>>(CacheProductKey).Any(expression.Compile()));
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            var product = _memoryCache.Get<IEnumerable<Product>>(CacheProductKey);
            return Task.FromResult(product);
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var product = _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return Task.FromResult(product);

            }
            else
            {
                throw new NotFoundException($"{typeof(Product).Name}-{id} not found");
            }
        }

        public Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoty()
        {
            var product = _memoryCache.Get<List<ProductWithCategoryDto>>(CacheProductKey);
            var products = _mapper.Map<List<ProductWithCategoryDto>>(product);
            return Task.FromResult(CustomResponseDto<List<ProductWithCategoryDto>>.Success(products, 200));
        }

        public async Task RemoveAsync(Product entity)
        {
            _productRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAll();
        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            _productRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAll();
        }

        public async Task UpdateAsync(Product entity)
        {
            _productRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAll();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAll()
        {
            await _memoryCache.Set(CacheProductKey, _productRepository.GetAll().ToListAsync());
        }
    }
}
