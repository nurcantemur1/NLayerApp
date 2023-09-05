using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entity;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>,ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;


        public CategoryService(IGenericRepository<Category> genericrepository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository repository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> CategoryWithProducts(int categoryId)
        {
            var category= await _repository.categoryWithProductsAsync(categoryId);
            var categoryDto =  _mapper.Map<CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Success(categoryDto,200);
        }
    }
}
