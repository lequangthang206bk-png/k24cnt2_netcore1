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

        // Danh sach san pham
        public IActionResult Index()
        {
            var products = _productService.GetAll();

            ViewData["Title"] = "Danh sách sản phẩm";
            ViewBag.Message = "Quản lý sản phẩm";

            return View(products);
        }

        // Hien thi form them san pham
        public IActionResult Create()
        {
            return View();
        }

        // Xu ly them san pham
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.Add(product);

            TempData["ThongBao"] = "Thêm sản phẩm thành công!";

            return RedirectToAction("Index");
        }

        // Xem chi tiet san pham
        public IActionResult Details(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Hien thi form sua san pham
        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Xu ly sua san pham
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _productService.Update(product);

            TempData["ThongBao"] = "Cập nhật sản phẩm thành công!";

            return RedirectToAction("Index");
        }

        // Hien thi trang xac nhan xoa
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Xu ly xoa san pham
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);

            TempData["ThongBao"] = "Xóa sản phẩm thành công!";

            return RedirectToAction("Index");
        }
    }
}