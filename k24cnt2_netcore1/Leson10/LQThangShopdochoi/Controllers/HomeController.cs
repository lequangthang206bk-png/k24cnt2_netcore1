using Microsoft.AspNetCore.Mvc;
using LQThangShopdochoi.Models;

namespace LQThangShopdochoi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository _repository;

        public HomeController(ProductRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(string? category, string? keyword)
        {
            var products = _repository.GetAll().AsEnumerable();

            if (!string.IsNullOrWhiteSpace(category) && category != "Tất cả")
                products = products.Where(p => p.Category == category);

            if (!string.IsNullOrWhiteSpace(keyword))
                products = products.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                               p.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                               (p.Description ?? "").Contains(keyword, StringComparison.OrdinalIgnoreCase));

            ViewBag.Category = category ?? "Tất cả";
            ViewBag.Keyword = keyword ?? "";
            ViewBag.Categories = _repository.GetAll()
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            return View(products.ToList());
        }

        public IActionResult Details(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
