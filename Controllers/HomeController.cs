using Microsoft.AspNetCore.Mvc;
using scheduler.Interfaces;

namespace scheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepo;

        public HomeController(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "What is the Scheduler?";

            return View();
        }

        public IActionResult Schedule()
        {
            ViewData["Message"] = "Schedule a Meeting";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
