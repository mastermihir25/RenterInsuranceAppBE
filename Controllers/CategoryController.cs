using Microsoft.AspNetCore.Mvc;
using RenterInsuranceApp.Models;
using RenterInsuranceApp.Utilities;

namespace RenterInsuranceApp.Controllers
{
    [ApiController]
    [Route("api/Categories")]
    public class CategoryController : ControllerBase
    {
        private static readonly string[] categories = new[]
        { "Electronics", "Jewelry", "Furniture", "Clothing", "Others" };

        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                return Ok(ApiResponse<IEnumerable<string>>.Success(categories));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching items: {ex.Message}");
                return BadRequest(ApiResponse<IEnumerable<string>>.Fail("An error occurred while fetching items."));
            }
        }
    }
}
