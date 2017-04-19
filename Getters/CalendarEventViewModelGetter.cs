using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using scheduler.Helpers;
using scheduler.Interfaces;
using scheduler.Mappers;
using scheduler.Models;
using scheduler.Models.DatabaseModels;
using scheduler.Models.SchedulerViewModels;

namespace scheduler.Getters
{
    public class CalendarEventViewModelGetter
    {
        private readonly IEventRepository _eventRepo;
        private readonly IInviteeRepository _inviteeRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly InviteeHelper _inviteeHelper;

        public CalendarEventViewModelGetter(IEventRepository eventRepo, IInviteeRepository inviteeRepo, UserManager<ApplicationUser> userManager)
        {
            _eventRepo = eventRepo;
            _inviteeRepo = inviteeRepo;
            _userManager = userManager;
            _inviteeHelper = new InviteeHelper(inviteeRepo, userManager);
        }

        public async Task<List<CalendarEventViewModel>> GetByUserId(string userId)
        {
            var calendarEventViewModels = new List<CalendarEventViewModel>();

            var eventsForUser = GetEventsForUser(userId);
            foreach(var eventModel in eventsForUser)
            {
                var inviteeUserEmails = await _inviteeHelper.GetInviteeEmails(eventModel.Id);

                var calendarViewModel = CalendarEventViewModelMapper.MapFrom(eventModel, inviteeUserEmails);
                calendarEventViewModels.Add(calendarViewModel);
            }

            //fix how events are ordered
            return calendarEventViewModels.OrderBy(x => x.StartDateTime).ToList();
        }

        private List<Event> GetEventsForUser(string userId)
        {
            var eventsForUser = _eventRepo.GetByCreatedId(userId);

            var inviteesForUser = _inviteeRepo.GetByUserId(userId);
            var eventsUserInvitedTo = new List<Event>();
            foreach (var invitee in inviteesForUser)
            {
                var events = _eventRepo.GetById(invitee.EventId);
                eventsUserInvitedTo.Add(events);
            }

            eventsForUser.AddRange(eventsUserInvitedTo);
            return eventsForUser.Where(x => x != null).ToList();
        }
    }
}