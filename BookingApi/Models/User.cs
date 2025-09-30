namespace BookingApi.Models;

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    //Determine if the user is an Admin or Not
    public string Role { get; set; }
    public string Email { get; set; }
    
}