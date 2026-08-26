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

        public IActionResult Index()
        {
            var products = _productService.GetAll();

            ViewData["Title"] = "Danh sách sản phẩm";
            ViewBag.Message = "Quản lý sản phẩm";

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.Add(product);

            TempData["ThongBao"] = "Thêm sản phẩm thành công!";

            return RedirectToAction("Index");
        }

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

            TempData["ThongBao"] = "Cập nhật sản phẩm thành công!";

            return RedirectToAction("Index");
        }

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

            TempData["ThongBao"] = "Xóa sản phẩm thành công!";

            return RedirectToAction("Index");
        }
    }
}