using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using scheduler.Getters;
using scheduler.Helpers;
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
        private readonly CalendarEventViewModelGetter _calendarViewModelGetter;
        private readonly InviteeHelper _inviteeHelper;

        public SchedulerController(UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory, IEventRepository eventRepo, IInviteeRepository inviteeRepo) 
        {
            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<SchedulerController>();
            _eventRepo = eventRepo;
            _inviteeRepo = inviteeRepo;
            _calendarViewModelGetter = new CalendarEventViewModelGetter(eventRepo, inviteeRepo, userManager);
            _inviteeHelper = new InviteeHelper(inviteeRepo, userManager);
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

            var emails = _inviteeHelper.GetInviteeEmailsFromView(model);
            foreach(var email in emails)
            {
                var result = await _inviteeHelper.AddInviteeFromEmail(email, currentUser, newEvent);
            }
            
            return RedirectToAction("ViewCalendar", "Scheduler");
        }

        [HttpGet]
        public async Task<IActionResult> ViewCalendar()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var calendarViewModels = await _calendarViewModelGetter.GetByUserId(currentUser.Id);
            return View("ViewCalendar", calendarViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> EditEvent(int eventId)
        {
            var eventModel = _eventRepo.GetById(eventId);
            var eventInviteesEmails = await _inviteeHelper.GetInviteeEmails(eventId);

            var eventViewModel = EventViewModelMapper.MapFrom(eventModel, eventInviteesEmails);
            return View(eventViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEvent(EventViewModel model)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var eventDbModel = EventModelMapper.MapFrom(currentUser, model);
            var updatedEvent = _eventRepo.Update(eventDbModel);

            var newInvitees = _inviteeHelper.GetInviteeEmailsFromView(model).OrderBy(x => x).ToList();
            var currentInvitees = await _inviteeHelper.GetInviteeEmails(updatedEvent.Id);
            var sortedCurrentInvitees = currentInvitees.OrderBy(x => x).ToList();

            var inviteesToAdd = newInvitees.Except(sortedCurrentInvitees).ToList();
            foreach(var inviteeToAdd in inviteesToAdd)
            {
                var result = await _inviteeHelper.AddInviteeFromEmail(inviteeToAdd, currentUser, updatedEvent);
            }

            var inviteesToRemove = sortedCurrentInvitees.Except(newInvitees).ToList();
            foreach(var inviteeToRemove in inviteesToRemove)
            {
                var result = await _inviteeHelper.RemoveInviteeFromEmail(inviteeToRemove, updatedEvent);
            }

            return RedirectToAction("ViewCalendar", "Scheduler");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveEvent(int eventId)
        {
            var eventModel = _eventRepo.GetById(eventId);
            var eventInviteesEmails = await _inviteeHelper.GetInviteeEmails(eventId);

            var eventViewModel = EventViewModelMapper.MapFrom(eventModel, eventInviteesEmails);
            return View(eventViewModel);
        }

        [HttpPost] async Task<IActionResult> DeleteEvent(EventViewModel model)
        {
            return RedirectToAction("ViewCalendar", "Scheduler");
        }
    }
}