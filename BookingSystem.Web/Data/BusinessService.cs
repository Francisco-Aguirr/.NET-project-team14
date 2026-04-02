using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Web.Data
{
    public class BusinessService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        public Business? Business { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Range(0, 99999)]
        public decimal Price { get; set; }

        [Range(5, 480)]
        public int DurationMinutes { get; set; } = 30;

        public bool IsActive { get; set; } = true;
    }
}
