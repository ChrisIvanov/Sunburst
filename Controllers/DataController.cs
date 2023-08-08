namespace Sunburst.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Sunburst.Models.Shop.Item;
    using Sunburst.Services.Contracts.DataContracts;

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IItemService _itemService;

        public DataController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemModel itemModel) 
        {
            if (itemModel == null)
            {
                return Conflict("Invalid item data.");
            }

            try
            {
                await _itemService.CreateItemAsync(itemModel);
                return Ok("Success!");
            }
            catch (Exception)
            {
                return BadRequest("Invalid item data.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllItemsAsync();

            if (items != null && items.Count() > 0)
            {
                return Ok(items);
            }
            else
            {
                return Conflict("No items.");
            }
        }
    }
}
