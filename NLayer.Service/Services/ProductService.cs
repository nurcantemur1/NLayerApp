using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> genericrepository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository repository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoty()
        {
            var products = await _repository.GetProductsWithCategoty();
            var newproducts =  _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(newproducts,200); ;
        }
        
    }
}
