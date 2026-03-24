using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Web.Data
{
    public class BusinessCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}