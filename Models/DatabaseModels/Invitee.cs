using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scheduler.Models.DatabaseModels
{
    public class Invitee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKeyAttribute("Event")]
        public int EventId { get; set; }
        [Required]
        [ForeignKeyAttribute("ApplicationUser")]
        public string UserId { get; set; }
        [Required]
        public bool Accepted { get; set; }
    }
}