using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.WebApp.Services;

namespace NLayer.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductController(ProductApiService productApiService, CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var customResponseData = await _productApiService.ProductWithCategoryDtos();
            return View(customResponseData);
        }
        public async Task<IActionResult> GetProduct(int id)
        {
            var customResponseData = await _productApiService.GetById(id);
            return View(customResponseData);
        }

        public async Task<IActionResult> Add()
        {
            var categories = await _categoryApiService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductDto productDto)
        {

            if (ModelState.IsValid)
            {
                await _productApiService.Add(productDto);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryApiService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        // [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetById(id);

            var categories = await _categoryApiService.GetAllCategories();
            foreach (var item in categories)
            {
                Console.WriteLine(item.Name);
            }
            ViewBag.Categories = new SelectList(categories, "Id", "Name", product.CategoryId);

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.Update(productDto);
                return RedirectToAction(nameof(Index));
            }


            var categories = await _categoryApiService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", productDto.CategoryId);
            return View(productDto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productApiService.GetById(id);
            await _productApiService.Remove(product.Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
