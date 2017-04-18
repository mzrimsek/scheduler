using System.Collections.Generic;
using scheduler.Models.DatabaseModels;
using scheduler.Models.SchedulerViewModels;

namespace scheduler.Mappers
{
    public static class CalendarEventViewModelMapper
    {
        public static CalendarEventViewModel MapFrom(Event calendarEvent, List<string> inviteeEmails)
        {
            return new CalendarEventViewModel
            {
                EventId = calendarEvent.Id,
                EventTitle = calendarEvent.Title,
                EventDescription = calendarEvent.Description,
                StartDateTime = calendarEvent.StartTime.ToString(),
                EndDateTime = calendarEvent.EndTime.ToString(),
                InviteeEmails = inviteeEmails
            };
        }
    }
}