using System.Collections.Generic;
using scheduler.Interfaces;
using scheduler.Models.DatabaseModels;
using scheduler.Models.SchedulerViewModels;

namespace scheduler.Getters
{
    public class CalendarEventViewModelGetter
    {
        private readonly IEventRepository _eventRepo;
        private readonly IInviteeRepository _inviteeRepo;

        public CalendarEventViewModelGetter(IEventRepository eventRepo, IInviteeRepository inviteeRepo)
        {
            _eventRepo = eventRepo;
            _inviteeRepo = inviteeRepo;
        }

        public List<CalendarEventViewModel> GetByUserId(string userId)
        {
            var calendarEventViewModels = new List<CalendarEventViewModel>();

            var eventsForUser = GetEventsForUser(userId);

            return calendarEventViewModels;
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
    }
}