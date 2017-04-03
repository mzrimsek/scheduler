using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scheduler.Models.DatabaseModels
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKeyAttribute("ApplicationUser")]
        public int CreatedById { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        
    }
}