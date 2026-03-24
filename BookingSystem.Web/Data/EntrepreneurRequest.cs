using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Web.Data
{
    public class EntrepreneurRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public bool IsApproved { get; set; } = false;

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    }
}