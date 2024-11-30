using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RenterInsuranceApp.Data;
using RenterInsuranceApp.Models;

namespace RenterInsuranceApp.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            if(_context.Items!= null)
                return await _context.Items.ToListAsync();
            else
                return Enumerable.Empty<Item>();
        }

        public async Task<Item> GetByIdAsync(Guid id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> AddAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
