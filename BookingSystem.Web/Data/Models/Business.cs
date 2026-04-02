using BookingSystem.Web.Data;

public class Business
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public ApplicationUser? User { get; set; }

    public int BusinessCategoryId { get; set; } 
    public BusinessCategory? BusinessCategory { get; set; }  
}