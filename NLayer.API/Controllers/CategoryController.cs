using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
 
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> CategoryWithProducts(int id)
        {
            return CreateActionResult(await categoryService.CategoryWithProducts(id));
        }
    }
}
