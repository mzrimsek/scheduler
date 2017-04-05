using Microsoft.AspNetCore.Mvc;
using scheduler.Data;
using scheduler.Models.DatabaseModels;
using scheduler.Repositories;

namespace scheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventRepository _eventRepo;

        public HomeController()
        {
            var context = new ApplicationDbContext();
            _eventRepo = new EventRepository(context);
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
