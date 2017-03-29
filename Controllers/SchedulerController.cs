using Microsoft.AspNetCore.Mvc;

namespace scheduler.Controllers
{
    public class SchedulerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}