using BookingApi.Models;
using BookingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers;

[ApiController]
[Route("api/controller")]
public class BookingController : ControllerBase
{
    private readonly BookingService _bookingService;

    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet] //Gets all the bookings
    public async Task<IActionResult>GetAll()
    {
        var bookings = await _bookingService.GetAllBookings();
        return Ok(bookings);
    }

    [HttpGet("{id}")] //Gets a booking by the ID
    public async Task<IActionResult> GetBookingById(int id)
    {
        var booking = await _bookingService.GetBookingById(id);
        if (booking == null)
            return NotFound();

        return Ok(booking);
    }

    [HttpPost] //Creates a new booking
    public async Task<IActionResult> CreateBooking(Booking booking)
    {
        var newBooking = await _bookingService.CreateBooking(booking);
        return CreatedAtAction(nameof(GetBookingById), new { id = newBooking.BookingId }, newBooking);
    }

    [HttpPut("{id}")] //Updates an existing booking
    public async Task<IActionResult> UpdateBooking(int id, Booking booking)
    {
        if (id != booking.BookingId)
            return BadRequest();

        var success = await _bookingService.UpdateBooking(booking);
        if (!success)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")] //Delete a booking via ID
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _bookingService.DeleteBooking(id);
        if (!success)
            return NotFound();
        
        return NoContent();
    }

}