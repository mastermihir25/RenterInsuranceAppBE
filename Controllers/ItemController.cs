using Microsoft.AspNetCore.Mvc;
using RenterInsuranceApp.Logging;
using RenterInsuranceApp.Models;
using RenterInsuranceApp.Models.DTOs;
using RenterInsuranceApp.Services;
using RenterInsuranceApp.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RenterInsuranceApp.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILoggerManager _logger;

        public ItemController(IItemService itemService, ILoggerManager logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            try
            {
                var items = await _itemService.GetAllItemsAsync();
                return Ok(ApiResponse<IEnumerable<Item>>.Success(items));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching items: {ex.Message}");
                return BadRequest(ApiResponse<IEnumerable<Item>>.Fail("An error occurred while fetching items."));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemDto itemDto)
        {
            if (itemDto == null)
            {
                return BadRequest(ApiResponse<Item>.Fail("Invalid request data."));
            }

            try
            {
                var item = await _itemService.AddItemAsync(itemDto);
                return CreatedAtAction(nameof(GetAllItems), new { id = item.Id }, ApiResponse<Item>.Success(item, 201));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding item: {ex.Message}");
                return BadRequest(ApiResponse<Item>.Fail("An error occurred while adding the item."));
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            try
            {
                await _itemService.DeleteItemAsync(id);
                return Ok(ApiResponse<string>.Success("Item deleted successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting item with ID {id}: {ex.Message}");
                return BadRequest(ApiResponse<string>.Fail("An error occurred while deleting the item."));
            }
        }
    }

}
