using TooliRent.Services.DTOs.BookingDtos;

namespace TooliRent.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto?> GetBookingByIdAsync(int bookingId);
        Task<IEnumerable<BookingDto>> GetBookingsByUserIdAsync(string userId);
        Task<IEnumerable<BookingDto>> GetBookingsByToolIdAsync(int toolId);
        Task<IEnumerable<BookingDto>> GetActiveBookingsAsync();
        Task<IEnumerable<BookingDto>> GetBookingsActiveWithinDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<BookingDto>> GetBookingsByPickupStatusAsync(bool isPickedUp);
        Task<IEnumerable<BookingDto>> GetBookingsByReturnStatusAsync(bool isReturned);
        Task<BookingDto?> CreateBookingAsync(CreateBookingDto createBookingDto);
        Task<bool> UpdateBookingAsync(int bookingId, UpdateBookingDto updateBookingDto);
        Task<bool> DeleteBookingAsync(int bookingId);
        Task<bool> CancelBookingAsync(int bookingId);
        Task<bool> MarkBookingAsPickedUpAsync(int bookingId);
        Task<IEnumerable<BookingDto>> GetNotHandledLateReturnedBookings();
        Task<bool> MarkLateReturnAsHandled(int id);
        Task<bool> MarkBookingAsReturnedAsync(int bookingId);
        Task<bool> BookingExistsAsync(int bookingId);
    }
}
