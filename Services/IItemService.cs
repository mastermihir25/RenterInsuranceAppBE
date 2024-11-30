using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RenterInsuranceApp.Models;
using RenterInsuranceApp.Models.DTOs;

namespace RenterInsuranceApp.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> AddItemAsync(ItemDto itemDto);
        Task DeleteItemAsync(Guid id);
    }

}
