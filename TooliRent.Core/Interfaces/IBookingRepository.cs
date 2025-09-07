using TooliRent.Core.Models;

namespace TooliRent.Core.Interfaces
{
    public interface IBookingRepository : IRepository<Booking>
    {
        public Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId);
        public Task<IEnumerable<Booking>> GetBookingsByToolIdAsync(int toolId);
        public Task<IEnumerable<Booking>> GetActiveBookingsAsync();
        public Task<IEnumerable<Booking>> GetBookingsWithinDateRangeAsync(DateTime startDate, DateTime endDate);
        public Task<IEnumerable<Booking>> GetBookingsByPickupStatusAsync(bool isPickedUp);
    }
}
