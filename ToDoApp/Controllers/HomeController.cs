using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
