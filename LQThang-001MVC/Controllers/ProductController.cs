using LQThang_001MVC.Models;
using LQThang_001MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace LQThang_001MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // =========================
        // DANH SÁCH
        // =========================

        public IActionResult Index()
        {
            var products = _productService.GetAll();

            return View(products);
        }


        // =========================
        // THÊM
        // =========================

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.Add(product);

            return RedirectToAction("Index");
        }


        // =========================
        // SỬA
        // =========================

        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _productService.Update(product);

            return RedirectToAction("Index");
        }


        // =========================
        // XÓA
        // =========================

        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}