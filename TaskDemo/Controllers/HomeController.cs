using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskDemo.Models;

namespace TaskDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
