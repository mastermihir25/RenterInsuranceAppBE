using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RenterInsuranceApp.Logging;
using RenterInsuranceApp.Models;
using RenterInsuranceApp.Models.DTOs;
using RenterInsuranceApp.Repositories;

namespace RenterInsuranceApp.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ILoggerManager _logger;

        public ItemService(IItemRepository itemRepository, ILoggerManager logger)
        {
            _itemRepository = itemRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            _logger.LogInfo("Fetching all items...");
            var items = await _itemRepository.GetAllAsync();
            _logger.LogInfo($"Retrieved {items.Count()} items.");
            return items;
        }

        public async Task<Item> AddItemAsync(ItemDto itemDto)
        {
            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Value = itemDto.Value,
                Category = itemDto.Category
            };

            var addedItem = await _itemRepository.AddAsync(item);
            _logger.LogInfo($"Item added: {item.Name}, Value: {item.Value}, Category: {item.Category}");
            return addedItem;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            await _itemRepository.DeleteAsync(id);
            _logger.LogInfo($"Item with ID {id} deleted.");
        }
    }

}
