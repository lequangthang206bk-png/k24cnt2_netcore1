using Microsoft.AspNetCore.Mvc;

namespace LQTLesson14.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
