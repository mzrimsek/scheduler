using System.Collections.Generic;
using scheduler.Models;
using scheduler.Models.DatabaseModels;
using scheduler.Models.SchedulerViewModels;

namespace scheduler.Mappers
{
    public static class CalendarEventViewModelMapper
    {
        public static CalendarEventViewModel MapFrom(Event calendarEvent, ApplicationUser eventOwner, List<string> inviteeEmails)
        {
            return new CalendarEventViewModel
            {
                EventId = calendarEvent.Id,
                CreatedById = eventOwner.Id,
                CreatedByEmail = eventOwner.Email,
                EventTitle = calendarEvent.Title,
                EventDescription = calendarEvent.Description,
                StartDateTime = calendarEvent.StartTime.ToString(),
                EndDateTime = calendarEvent.EndTime.ToString(),
                InviteeEmails = inviteeEmails
            };
        }
    }
}