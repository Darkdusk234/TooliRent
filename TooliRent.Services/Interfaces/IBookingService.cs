using TooliRent.Services.DTOs;

namespace TooliRent.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto?> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(string userId);
        Task<IEnumerable<BookingDto>> GetBookingsByToolIdAsync(int toolId);
        Task<IEnumerable<BookingDto>> GetActiveBookingsAsync();
        Task<IEnumerable<BookingDto>> GetBookingsWithLastDateWithinDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<BookingDto>> GetBookingsByPickupStatusAsync(bool isPickedUp);
        Task<IEnumerable<BookingDto>> GetBookingsByCancellationStatusAsync(bool isCancelled);
        Task<IEnumerable<BookingDto>> GetBookingsByReturnStatusAsync(bool isReturned);
        Task<BookingDto> CreateBookingAsync(CreateBookingDto createBookingDto);
        Task<bool> UpdateBookingAsync(int bookingId, UpdateBookingDto updateBookingDto);
        Task<bool> DeleteBookingAsync(int bookingId);
        Task<bool> CancelBookingAsync(int bookingId);
        Task<bool> BookingExistsAsync(int bookingId);
    }
}
