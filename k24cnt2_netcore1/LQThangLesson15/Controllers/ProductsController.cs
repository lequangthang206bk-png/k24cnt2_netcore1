using LQThangLesson15.Data;
using LQThangLesson15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LQThangLesson15.Controllers;

public class ProductsController : Controller
{
    private readonly LqtLesson15DbContext _db;

    public ProductsController(LqtLesson15DbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        return View(await LoadProducts());
    }

    public async Task<IActionResult> Search(string? keyword)
    {
        ViewData["ProductId"] = keyword;

        try
        {
            var query = _db.Products.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(x => x.Name.Contains(keyword) || x.Category.Contains(keyword));
            }
            return View(await query.OrderBy(x => x.Id).ToListAsync());
        }
        catch
        {
            var products = LqtProductData.GetDefault();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                products = products.Where(x => x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) || x.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(products);
        }
    }

    public async Task<IActionResult> Hots()
    {
        return View((await LoadProducts()).Take(4).ToList());
    }

    private async Task<List<LqtProduct>> LoadProducts()
    {
        try
        {
            return await _db.Products.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }
        catch
        {
            return LqtProductData.GetDefault();
        }
    }
}
