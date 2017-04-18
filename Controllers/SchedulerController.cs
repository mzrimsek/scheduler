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
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
            if (user != null) {
                return View(); 
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventViewModel model) 
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var eventDbModel = EventModelMapper.MapFrom(currentUser, model);
            var newEvent = _eventRepo.Create(eventDbModel);

            var emails = model.InviteeEmails.Split(',');
            foreach(var email in emails)
            {
                var trimmedEmail = email.Trim();
                if(!string.IsNullOrEmpty(trimmedEmail))
                {
                    var inviteeUser = await _userManager.FindByEmailAsync(trimmedEmail);
                    if(inviteeUser != null)
                    {
                        var inviteeDbModel = InviteeModelMapper.MapFrom(newEvent, inviteeUser);
                        _inviteeRepo.Create(inviteeDbModel);
                    }
                    
                }
            }

            // this should redirect to the calendar page
            return RedirectToAction("Index", "Scheduler");
        }
    }
}