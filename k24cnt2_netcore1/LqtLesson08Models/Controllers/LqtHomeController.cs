using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LqtLesson08Models.Models;

namespace LqtLesson08Models.Controllers
{
    public class LqtHomeController : Controller
    {
        private readonly ILogger<LqtHomeController> _logger;

        public LqtHomeController(ILogger<LqtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LqtIndex()
        {
            return View();
        }

        public IActionResult LqtPrivacy()
        {
            return View();
        }

        public IActionResult LqtAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
