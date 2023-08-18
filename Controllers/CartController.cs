namespace Sunburst.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sunburst.Data.Models.Shop;
    using Sunburst.Models.Shop.Cart;
    using Sunburst.Models.Shop.Item;
    using Sunburst.Services.Contracts.DataContracts;

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("/api/Cart/Check/{userName}")]
        public async Task<IActionResult> CheckIfCartExists(string userName)
        {
            var response = this._cartService.CheckIfCartExists(userName);

            if (response.Result == false)
            {
                return Ok(false);
                
            }

            return Ok(true);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] CreateCartModel cartModel)
        {
            var result = await _cartService.CreateCartAsync(cartModel);

            if (result != 1)
            {
                return BadRequest("Failed to create cart.");
            }

            return Ok("Successfully created cart.");
        }

        [HttpPut]
        public async Task<IActionResult> EditCart([FromBody] EditCartModel cartModel)
        {
            var result = await _cartService.UpdateCartAsync(cartModel);

            if (result != 1)
            {
                return BadRequest("Failed to update cart.");
            }

            return Ok("Successfully updated cart.");
        }

        [HttpDelete("/api/Cart/{id}")]
        public async Task<IActionResult> DeleteCart([FromBody] int cartId)
        {
            var result = await _cartService.DeleteCartAsync(cartId);

            if (result != 1)
            {
                return BadRequest("Failed to delete cart.");
            }

            return Ok("Successfully delete cart.");
        }

        [HttpGet("/api/Cart/GetAll")]
        public async Task<IActionResult> GetAllCartsAsync()
        {
            var carts = await _cartService.GetAllCartsAsync();

            if (carts == null)
            {
                return BadRequest("Failed to fetch carts or no carts in the database.");
            }

            return Ok(carts);
        }

        [HttpGet("/api/Cart/GetCartItem/{cartItem}")]
        public async Task<IActionResult> GetCartItems(string userName)
        {
            var cartsItem = await _cartService.GetCartItems(userName);

            if (cartsItem == null)
            {
                return BadRequest("Failed to fetch cart items or no cart items in the cart.");
            }

            return Ok(cartsItem);
        }

        [HttpGet("/api/Cart/GetCartByUserName/{userName}")]
        public async Task<IActionResult> GetCartsByUserName(string userName)
        {
            var carts = await _cartService.GetCartsByUserName(userName);

            if (carts == null)
            {
                return BadRequest("Failed to fetch carts or no carts connected with this user in the database.");
            }

            return Ok(carts);
        }
    }
}
