using Microsoft.EntityFrameworkCore;
using TooliRent.Core.Interfaces;
using TooliRent.Core.Models;
using TooliRent.Infrastructure.Data;

namespace TooliRent.Infrastructure.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ToolIRentDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetActiveBookingsAsync()
        {
            return await _dbSet.Where(b => b.ReturnDate == DateTime.MinValue).ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByPickupStatusAsync(bool isPickedUp)
        {
            return await _dbSet.Where(b => b.IsPickedUp == isPickedUp).ToListAsync();
        }

        public Task<IEnumerable<Booking>> GetBookingsByToolIdAsync(int toolId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetBookingsWithinDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
