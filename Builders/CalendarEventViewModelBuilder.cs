using System.Collections.Generic;
using scheduler.Interfaces;
using scheduler.Models.DatabaseModels;
using scheduler.Models.SchedulerViewModels;

namespace scheduler.Builders
{
    public class CalendarEventViewModelBuilder
    {
        private readonly IEventRepository _eventRepo;
        private readonly IInviteeRepository _inviteeRepo;

        public CalendarEventViewModelBuilder(IEventRepository eventRepo, IInviteeRepository inviteeRepo)
        {
            _eventRepo = eventRepo;
            _inviteeRepo = inviteeRepo;
        }

        public CalendarEventViewModel BuildFrom(string userId)
        {
            var eventsForUser = GetEventsForUser(userId);
            
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