using Microsoft.AspNetCore.Mvc;
using scheduler.Interfaces;
using scheduler.Models.DatabaseModels;

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

        public IActionResult Error()
        {
            return View();
        }

        public void Save(Event newEvent)
        {
            _eventRepo.Create(newEvent);
        }
    }
}
