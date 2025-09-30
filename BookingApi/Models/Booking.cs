namespace BookingApi.Models;

public class Booking
{
    public int BookingId { get; set; }
    public int OrganizationId { get; set; } //Foreign key
    public Organization Organization { get; set; }
    
    public string ContactPerson { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public int NumberOfParticipants { get; set; }
    public string Status { get; set; } //Accepted or Rejected

}