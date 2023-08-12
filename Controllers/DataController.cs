namespace Sunburst.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Sunburst.Data.Models.Shop;
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

        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromBody] EditItemModel model)
        {
            var result = await _itemService.UpdateItemAsync(model);

            if (result == 1)
            {
                return Ok();
            }
            else
            {
                return Conflict($"The item {model.Name} was not edited");
            }
        }

        [HttpGet("items")]
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

        [HttpGet("items/{name}")]
        public async Task<IActionResult> GetItemByName(string name)
        {
            var items = await _itemService.GetItemByName(name);

            if (items != null)
            {
                return Ok(items);
            }
            else
            {
                return Conflict("No such item exists.");
            }
        }

        [HttpGet("items/{category}")]
        public async Task<IActionResult> GetItemsByCategory(string category)
        {
            var items = await _itemService.GetItemsByCategory(category);

            if (items != null && items.Count() > 0)
            {
                return Ok(items);
            }
            else
            {
                return Conflict("No items.");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(string name)
        {
            var result = await _itemService.DeleteItemAsync(name);

            if (result == 1)
            {
                return Ok();
            }
            else
            {
                return Conflict("No item found by this name.");
            }
        }
    }
}
