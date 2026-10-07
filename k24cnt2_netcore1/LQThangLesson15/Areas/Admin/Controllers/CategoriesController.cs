using LQThangLesson15.Data;
using LQThangLesson15.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LQThangLesson15.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriesController : Controller
{
    private readonly LqtLesson15DbContext _db;

    public CategoriesController(LqtLesson15DbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var categories = await _db.Products.AsNoTracking().GroupBy(x => x.Category).Select(x => new LqtCategoryViewModel { Name = x.Key, Count = x.Count() }).ToListAsync();
            return View(categories);
        }
        catch
        {
            var categories = LqtProductData.GetDefault().GroupBy(x => x.Category).Select(x => new LqtCategoryViewModel { Name = x.Key, Count = x.Count() }).ToList();
            return View(categories);
        }
    }
}
