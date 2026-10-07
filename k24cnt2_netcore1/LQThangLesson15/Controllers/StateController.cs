using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace LQThangLesson15.Controllers;

public class StateController : Controller
{
    private readonly IMemoryCache _cache;

    public StateController(IMemoryCache cache)
    {
        _cache = cache;
    }

    public IActionResult Index()
    {
        HttpContext.Items["RequestTime"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        var count = HttpContext.Session.GetInt32("VisitCount") ?? 0;
        ViewBag.SessionCount = count;
        ViewBag.ItemValue = HttpContext.Items["RequestTime"];
        ViewBag.CacheValue = GetCacheValue();
        return View();
    }

    [HttpGet]
    public IActionResult Cookie()
    {
        ViewBag.CookieValue = Request.Cookies["LqtUserName"];
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cookie(string? userName)
    {
        var value = string.IsNullOrWhiteSpace(userName) ? "Lê Quang Thắng" : userName.Trim();
        Response.Cookies.Append("LqtUserName", value, new CookieOptions
        {
            HttpOnly = true,
            IsEssential = true,
            Expires = DateTimeOffset.Now.AddDays(7),
            SameSite = SameSiteMode.Lax
        });
        TempData["Message"] = "Cookie đã được lưu trong 7 ngày.";
        return RedirectToAction(nameof(Cookie));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SessionValue()
    {
        var count = HttpContext.Session.GetInt32("VisitCount") ?? 0;
        HttpContext.Session.SetInt32("VisitCount", count + 1);
        HttpContext.Session.SetString("LqtSessionUser", "Lê Quang Thắng");
        TempData["Message"] = "Session đã được cập nhật.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult TempDataValue()
    {
        TempData["Message"] = "Dữ liệu TempData đã được truyền sang request tiếp theo.";
        return RedirectToAction(nameof(TempDataResult));
    }

    public IActionResult TempDataResult()
    {
        ViewBag.Message = TempData["Message"];
        return View();
    }

    public IActionResult QueryString(string? keyword)
    {
        ViewBag.Keyword = keyword;
        return View();
    }

    [HttpGet]
    public IActionResult HiddenField()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult HiddenField(string? value)
    {
        ViewBag.HiddenValue = value;
        return View();
    }

    public IActionResult Items()
    {
        HttpContext.Items["Message"] = "HttpContext.Items chỉ tồn tại trong request hiện tại.";
        ViewBag.ItemMessage = HttpContext.Items["Message"];
        return View();
    }

    public IActionResult Cache()
    {
        ViewBag.CacheMessage = GetCacheValue();
        return View();
    }

    public IActionResult ItemsCache()
    {
        return RedirectToAction(nameof(Items));
    }

    private string GetCacheValue()
    {
        return _cache.GetOrCreate("LqtLesson15Cache", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
            return $"Cache được tạo lúc {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        })!;
    }
}
