using Microsoft.EntityFrameworkCore;
using TooliRent.Core.Interfaces;
using TooliRent.Core.Models;
using TooliRent.Infrastructure.Data;

namespace TooliRent.Infrastructure.Repositories
{
    public class ToolRepository : Repository<Tool>, IToolRepository
    {
        public ToolRepository(ToolIRentDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Tool>> GetToolsByAvailabilityAsync(bool available)
        {
            return await _dbSet.Where(t => t.Available == available).ToListAsync();
        }

        public async Task<IEnumerable<Tool>> GetToolsByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(t => t.CategoryId == categoryId).ToListAsync();
        }
    }
}
