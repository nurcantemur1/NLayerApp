using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CategoryWithProducts(int id)
        {
            await _categoryService.CategoryWithProducts(id);
            return CreateActionResult(await _categoryService.CategoryWithProducts(id));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var newlist =  _mapper.Map<List<CategoryDto>>(categories.ToList());
            foreach (var item in newlist)
            {
                Console.WriteLine(item.Name);
            }
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(newlist, 200));
        }
      

    }
}
