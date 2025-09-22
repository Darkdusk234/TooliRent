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

        public async override Task<IEnumerable<Tool>> GetAllAsync()
        {
            return await _dbSet.Include(t => t.Category).ToListAsync();
        }

        public async override Task<Tool?> GetByIdAsync(int id)
        {
            return await _dbSet.Where(t => t.Id == id).Include(t => t.Category).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tool>> GetToolsByAvailabilityAsync(bool available)
        {
            return await _dbSet.Where(t => t.Available == available).Include(t => t.Category).ToListAsync();
        }

        public async Task<IEnumerable<Tool>> GetToolsByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(t => t.CategoryId == categoryId).Include(t => t.Category).ToListAsync();
        }

        public async Task<bool> IsToolAvailableAsync(int toolId)
        {
            var existingTool = await GetByIdAsync(toolId);
            return existingTool.Available == true ? true : false;
        }
    }
}
