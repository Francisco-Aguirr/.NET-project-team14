using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Web.Data
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BusinessServiceId { get; set; }

        [ForeignKey("BusinessServiceId")]
        public BusinessService? BusinessService { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        [MaxLength(450)]
        public string? ClientUserId { get; set; }

        [Required]
        public DateTime AppointmentStart { get; set; }

        [Required]
        public DateTime AppointmentEnd { get; set; }

        public bool IsCancelled { get; set; }
    }
}
