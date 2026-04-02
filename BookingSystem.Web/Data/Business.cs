using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Web.Data
{
    public class Business
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Phone]
        [MaxLength(30)]
        public string? Phone { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<BusinessService> Services { get; set; } = new List<BusinessService>();
    }
}
