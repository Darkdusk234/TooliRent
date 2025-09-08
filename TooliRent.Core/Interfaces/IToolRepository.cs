using TooliRent.Core.Models;

namespace TooliRent.Core.Interfaces
{
    public interface IToolRepository : IRepository<Tool>
    {
        public Task<IEnumerable<Tool>> GetToolsByCategoryAsync(int categoryId);
        public Task<IEnumerable<Tool>> GetToolsByAvailabilityAsync(bool available);
        // Additional methods to maybe be added: Function to search for all tools still in the workshop by availability and if they have been pickuped 
        //in booking
    }
}
