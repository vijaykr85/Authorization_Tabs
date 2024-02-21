using Authorization_Tabs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Authorization_Tabs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string id, string password)
        {
            var user = "Admin";
            var pass = "12345";
            var e = "emp";
            var p = "1212";

            if (id == user && password == pass)
            {
                //var roles = new[] { "admin" };
                TempData["Roles"] = "admin";

                return RedirectToAction("Home");
            }
            else if (id == e && password == p)
            {
                TempData["Roles"] = "emp";
                return RedirectToAction("Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View();
            }
        }

        public IActionResult Home()
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
