using Microsoft.AspNetCore.Mvc;

namespace LeQuangThang2410900071_exam.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult LqtAbout()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}
