using LQThangLesson15.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LQThangLesson15.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : Controller
{
    private readonly LqtLesson15DbContext _db;

    public ProductsController(LqtLesson15DbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            return View(await _db.Products.AsNoTracking().ToListAsync());
        }
        catch
        {
            return View(LqtProductData.GetDefault());
        }
    }
}
