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
        private readonly IInviteeRepository _inviteeRepo;

        public SchedulerController(UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory, IEventRepository eventRepo, IInviteeRepository inviteeRepo) 
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<SchedulerController>();
            _eventRepo = eventRepo;
            _inviteeRepo = inviteeRepo;
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
            var eventDbModel = EventModelMapper.MapFrom(currentUser, model);
            var newEvent = _eventRepo.Create(eventDbModel);

            foreach(var email in model.InviteeEmails)
            {
                var userId = "id-found-searching-for-user-in-db-by-email";
                var inviteeDbModel = InviteeModelMapper.MapFrom(newEvent, userId);
                _inviteeRepo.Create(inviteeDbModel);
                
            }

            return View(model);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}