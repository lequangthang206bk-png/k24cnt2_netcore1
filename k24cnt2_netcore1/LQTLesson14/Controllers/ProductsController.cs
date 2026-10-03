using Microsoft.AspNetCore.Mvc;

namespace LQTLesson14.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Search(string keyword)
        {
            ViewData["ProductId"] = keyword;
            return View();
        }

        public IActionResult Hots()
        {
            
            return View();
        }   
    }
}
