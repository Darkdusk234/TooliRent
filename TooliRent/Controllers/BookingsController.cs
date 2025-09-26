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
            var bookings = await _bookingService.GetBookingsByReturnStatusAsync(isReturned);
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
        public async Task<IActionResult> GetBookingsActiveWithinDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var bookings = await _bookingService.GetBookingsActiveWithinDateRangeAsync(startDate, endDate);
            return Ok(bookings);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("statistics")]
        [ProducesResponseType(typeof(AdminStatisticDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAdminStatistics([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var statistics = await _bookingService.GetAdminStatisticsAsync(startDate, endDate);
            return Ok(statistics);
        }

        [HttpPut("cancel/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var canceled = await _bookingService.CancelBookingAsync(id);

            if (!canceled)
            {
                return NotFound("Active booking not found.");
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookingDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBooking = await _bookingService.CreateBookingAsync(createBookingDto);

            if (createdBooking == null)
            {
                return BadRequest("Tool or User doesn't exist. Or tool is not available during all these days.");
            }

            return CreatedAtAction(nameof(GetBookingById), new { id = createdBooking.Id }, createdBooking);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var deleted = await _bookingService.DeleteBookingAsync(id);
            if (!deleted)
            {
                return NotFound("Booking not found.");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await _bookingService.UpdateBookingAsync(id, updateBookingDto);

            if (!updated)
            {
                return NotFound("Booking, User or Tool not found.");
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("pickup/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PickupTools(int bookingId)
        {
            var pickedUp = await _bookingService.MarkBookingAsPickedUpAsync(bookingId);

            if (!pickedUp)
            {
                return NotFound("Active booking not found or tools already picked up.");
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("return/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReturnTools(int bookingId)
        {
            var returned = await _bookingService.MarkBookingAsReturnedAsync(bookingId);

            if (!returned)
            {
                return NotFound("Active booking not found or tools already returned.");
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("lateReturns")]
        [ProducesResponseType(typeof(IEnumerable<BookingDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLateReturnBookings()
        {
            var bookings = await _bookingService.GetNotHandledLateReturnedBookings();
            return Ok(bookings);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("lateReturnHandled/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> MarkLateReturnAsHandled(int id)
        {
            var handled = await _bookingService.MarkLateReturnAsHandled(id);

            if (!handled)
            {
                return NotFound("Late return booking not found or has no late return to handle.");
            }

            return NoContent();
        }
    }
}
