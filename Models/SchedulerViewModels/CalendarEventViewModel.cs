using System.Collections.Generic;

namespace scheduler.Models.SchedulerViewModels
{
    public class CalendarEventViewModel
    {
        public int EventId { get; set; }
        public string CreatedById { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public List<string> InviteeEmails { get; set; }

    }
}