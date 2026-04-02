using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Web.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        public ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
    }
}