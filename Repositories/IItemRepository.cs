using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RenterInsuranceApp.Models;

namespace RenterInsuranceApp.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(Guid id);
        Task<Item> AddAsync(Item item);
        Task DeleteAsync(Guid id);
    }
}
