using LQThangLesson9.Models;
using Microsoft.AspNetCore.Mvc;

namespace LQThangLesson9.Controllers;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        var student = new Student();
        return View(student);
    }
}
