using System.ComponentModel.DataAnnotations;

namespace scheduler.Models.SchedulerViewModels
{

    public class EventViewModel 
    {
        public int EventId { get; set; }
        [Required]
        public string EventTitle { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public string InviteeEmails { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
    }

}