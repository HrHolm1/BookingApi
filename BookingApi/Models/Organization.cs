namespace BookingApi.Models;

public class Organization
{
    public int OrganizationId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } //Partners, Schools or external companies wanting to book.
    public int FreeDaysPerYear { get; set; }
    
    public ICollection<Booking> Bookings { get; set; } // Navigation property
}