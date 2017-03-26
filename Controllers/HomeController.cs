using Microsoft.AspNetCore.Mvc;

namespace scheduler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "What is the Scheduler?";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
