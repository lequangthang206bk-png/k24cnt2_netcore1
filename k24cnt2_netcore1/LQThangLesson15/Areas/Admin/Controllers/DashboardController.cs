using LQThangLesson15.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LQThangLesson15.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly LqtLesson15DbContext _db;

    public DashboardController(LqtLesson15DbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            ViewBag.ProductCount = await _db.Products.CountAsync();
        }
        catch
        {
            ViewBag.ProductCount = LqtProductData.GetDefault().Count;
        }
        return View();
    }
}
