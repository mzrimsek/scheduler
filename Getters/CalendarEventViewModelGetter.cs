using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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

        public CalendarEventViewModelGetter(IEventRepository eventRepo, IInviteeRepository inviteeRepo, UserManager<ApplicationUser> userManager)
        {
            _eventRepo = eventRepo;
            _inviteeRepo = inviteeRepo;
            _userManager = userManager;
        }

        public async Task<List<CalendarEventViewModel>> GetByUserId(string userId)
        {
            var calendarEventViewModels = new List<CalendarEventViewModel>();

            var eventsForUser = GetEventsForUser(userId);
            foreach(var eventModel in eventsForUser)
            {
                var inviteeUserEmails = await GetInviteeEmails(eventModel.Id);

                var calendarViewModel = CalendarEventViewModelMapper.MapFrom(eventModel, inviteeUserEmails);
                calendarEventViewModels.Add(calendarViewModel);
            }

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
            return eventsForUser;
        }

        private async Task<List<string>> GetInviteeEmails(int eventId)
        {
            var invitees = _inviteeRepo.GetByEventId(eventId);
            var inviteeUserEmails = new List<string>();
            foreach(var invitee in invitees)
            {
                var inviteeUser = await _userManager.FindByIdAsync(invitee.UserId);
                inviteeUserEmails.Add(inviteeUser.Email);
            }

            return inviteeUserEmails;
        }
    }
}