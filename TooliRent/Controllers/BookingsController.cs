using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TooliRent.Services.DTOs.BookingDtos;
using TooliRent.Services.Interfaces;

namespace TooliRent.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>),StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound("Booking not Found");
            }
            return Ok(booking);
        }

        [HttpGet("active")]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActiveBookings()
        {
            var bookings = await _bookingService.GetActiveBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("pickup/{isPickedUp}")]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookingsByPickupStatus(bool isPickedUp)
        {
            var bookings = await _bookingService.GetBookingsByPickupStatusAsync(isPickedUp);
            return Ok(bookings);
        }

        [HttpGet("return/{isReturned}")]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookingsByReturnStatus(bool isReturned)
        {
            var bookings = await _bookingService.GetBookingsByPickupStatusAsync(isReturned);
            return Ok(bookings);
        }

        [HttpGet("tool/{toolId}")]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookingsByToolId(int toolId)
        {
            var bookings = await _bookingService.GetBookingsByToolIdAsync(toolId);
            return Ok(bookings);
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookingsByUserId(string userId)
        {
            var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);
            return Ok(bookings);
        }

        [HttpGet("daterange")]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookingsWithLastDateWithinDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var bookings = await _bookingService.GetBookingsWithLastDateWithinDateRangeAsync(startDate, endDate);
            return Ok(bookings);
        }
    }
}
