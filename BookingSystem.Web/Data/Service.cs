using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Web.Data
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        // 🔗 Relación con Business
        [ForeignKey("Business")]
        public int BusinessId { get; set; }

        public Business? Business { get; set; }
    }
}