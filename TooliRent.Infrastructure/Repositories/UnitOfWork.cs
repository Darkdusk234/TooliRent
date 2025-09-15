using Microsoft.EntityFrameworkCore;
using TooliRent.Core.Interfaces;
using TooliRent.Core.Models;
using TooliRent.Infrastructure.Data;

namespace TooliRent.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToolIRentDbContext _context;
        private IToolRepository _tools;
        private IBookingRepository _bookings;
        private IRepository<Category> _categories;

        public UnitOfWork(ToolIRentDbContext context)
        {
            _context = context;
        }

        public IToolRepository Tools => _tools ??= new ToolRepository(_context);

        public IBookingRepository Bookings => _bookings ??= new BookingRepository(_context);

        public IRepository<Category> Categories => _categories ??= new Repository<Category>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
