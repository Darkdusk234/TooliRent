using TooliRent.Core.Models;

namespace TooliRent.Core.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        public Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId);
        public Task<IEnumerable<Booking>> GetBookingsByToolIdAsync(int toolId);
        public Task<IEnumerable<Booking>> GetActiveBookingsAsync();
        public Task<IEnumerable<Booking>> GetBookingsActiveWithinDateRangeAsync(DateTime startDate, DateTime endDate);
        public Task<IEnumerable<Booking>> GetBookingsByPickupStatusAsync(bool isPickedUp);
        public Task<IEnumerable<Booking>> GetBookingsByReturnStatusAsync(bool isReturned);
        public Task<IEnumerable<Booking>> GetActiveToolBookingWithinDateRange(DateTime startDate, DateTime endDate, int toolId);
        public Task<IEnumerable<Booking>> GetNotHandledLateReturnedBookings();
        public Task<IEnumerable<Booking>> GetBookingsCreatedWithingDateRange(DateTime startDate, DateTime endDate);
    }
}
