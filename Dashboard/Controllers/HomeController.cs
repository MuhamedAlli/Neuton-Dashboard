

using Application.Contracts;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dashboard.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserReposatory _userse;
        private readonly IOrderReposatory _order;
        private readonly IProductReposatory _products;
        private readonly ISubCategoryReposatory _subCategories;

        public HomeController(ILogger<HomeController> logger, IUserReposatory userse ,
            IOrderReposatory orders,
            IProductReposatory products,
            ISubCategoryReposatory subCategories
            
            )
        {
            _logger = logger;
            _userse = userse;
            _order = orders;
            _products = products;
            _subCategories = subCategories;
        }

        public async Task<IActionResult> Index()
        {
            var users =await _userse.GetAllAsync();
            int usersCount = users.Count();

            var orders= await _order.GetAllAsync();
            ViewData["orders"] = orders.Count();
            var products = await _products.GetAllAsync();
            ViewData["products"] = products.Count();
            var subCategories = await _subCategories.GetAllAsync();
            ViewData["subCategories"] = subCategories.Count();
            return View(usersCount);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}