using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace scheduler.Models.SchedulerViewModels 
{

    public class EventViewModel 
    {

        [Required]
        public string EventTitle { get; set; }

        [Required]
        public string EventDescription { get; set; }

        [Required]
        public List<string> Invitees { get; set; }

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