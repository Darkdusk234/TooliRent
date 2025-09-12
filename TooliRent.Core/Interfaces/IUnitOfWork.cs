using TooliRent.Core.Models;

namespace TooliRent.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IToolRepository Tools { get; }
        IBookingRepository Bookings { get; }
        IRepository<Category> Categories { get; }
        Task<int> SaveChangesAsync();
    }
}
