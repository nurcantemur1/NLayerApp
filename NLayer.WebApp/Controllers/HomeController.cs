using Microsoft.AspNetCore.Mvc;
using NLayer.WebApp.Models;
using NLayer.WebApp.Services;

namespace NLayer.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoryApiService _categoryApiService;

        public HomeController(ILogger<HomeController> logger, CategoryApiService categoryApiService)
        {
            _logger = logger;
            _categoryApiService = categoryApiService;
        }

        public async  Task< IActionResult> Index()
        {
            var c = await _categoryApiService.GetAllCategories();

            return View(c);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }
    }
}