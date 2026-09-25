using Microsoft.AspNetCore.Mvc;
using LQThangShopdochoi.Models;

namespace LQThangShopdochoi.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;

        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string? keyword)
        {
            var products = _repository.GetAll().AsEnumerable();

            if (!string.IsNullOrWhiteSpace(keyword))
                products = products.Where(p =>
                    p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    p.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase));

            ViewBag.Keyword = keyword;
            return View(products.ToList());
        }

        public IActionResult Search(string? keyword)
        {
            return RedirectToAction(nameof(Index), new { keyword });
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            _repository.Add(product);
            TempData["Message"] = "Thêm sản phẩm thành công!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            if (!_repository.Update(product)) return NotFound();
            TempData["Message"] = "Cập nhật sản phẩm thành công!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            TempData["Message"] = "Xóa sản phẩm thành công!";
            return RedirectToAction(nameof(Index));
        }
    }
}
