using LQThang_001MVC.Models;
using LQThang_001MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LQThang_001MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

       
        public IActionResult Index(string? search)
        {
            ViewBag.name = "Lê Quang Thắng";

            var products = _productService.GetAll();

            
            if (!string.IsNullOrWhiteSpace(search))
            {
                products = products
                    .Where(p =>
                        p.Name.Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase
                        )
                        ||
                        p.Brand.Contains(
                            search,
                            StringComparison.OrdinalIgnoreCase
                        )
                    )
                    .ToList();
            }

            ViewBag.Search = search;

            return View(products);
        }

        
        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId =
                        Activity.Current?.Id
                        ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}