using BookingApi.DataAccess;
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Services;

public class BookingService
{
    private readonly BookingContext _context;

    public BookingService(BookingContext context)
    {
        _context = context;
    }
    
    //Get All Bookings and orgs that made them
    public async Task<List<Booking>> GetAllBookings()
    {
        return await _context.Bookings
            .Include(b => b.Organization)
            .ToListAsync();
    }
    
    //Get a booking via the ID
    public async Task<Booking?> GetBookingById(int id)
    {
        return await _context.Bookings
            .Include(b => b.Organization)
            .FirstOrDefaultAsync(b => b.BookingId == id);
    }
    
    //Create a new booking
    public async Task<Booking> CreateBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return booking;
    }
    
    //Update an existing booking
    public async Task<bool> UpdateBooking(Booking booking)
    {
        if (!_context.Bookings.Any(b => b.BookingId == booking.BookingId))
            return false;

        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
        return true;
    }
    
    //Delete a booking by the ID
    public async Task<bool> DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
            return false;

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return true;
    }
    
}