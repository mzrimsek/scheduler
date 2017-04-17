using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using scheduler.Interfaces;
using scheduler.Mappers;
using scheduler.Models;
using scheduler.Models.SchedulerViewModels;

namespace scheduler.Controllers
{
    public class SchedulerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;
        private readonly IEventRepository _eventRepo;

        public SchedulerController(UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory, IEventRepository eventRepo) 
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<SchedulerController>();
            _eventRepo = eventRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            
            if (user != null) {
                return View(); 
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventViewModel model) 
        {
            var currentUser = await GetCurrentUserAsync();
            var eventModel = EventModelMapper.MapFrom(currentUser, model);
            var newEvent = _eventRepo.Create(eventModel);

            //need to add invitees

            return View(model);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}