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

        public Task<IEnumerable<Booking>> GetBookingsByReturnStatusAsync(bool isReturned)
        {
            if(isReturned)
            {
                return Task.FromResult(_dbSet.Where(b => b.ReturnDate == DateTime.MinValue).AsEnumerable());
            }
            else
            {
                return Task.FromResult(_dbSet.Where(b => b.ReturnDate != DateTime.MinValue).AsEnumerable());
            }
        }

        public async Task<IEnumerable<Booking>> GetBookingsByToolIdAsync(int toolId)
        {
            return await _dbSet.Where(b => b.ToolId == toolId).ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(string userId)
        {
            return await _dbSet.Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsWithLastDateWithinDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbSet.Where(b => (b.LastBookedDate >= startDate && b.LastBookedDate <= endDate)).ToListAsync();
        }
    }
}
