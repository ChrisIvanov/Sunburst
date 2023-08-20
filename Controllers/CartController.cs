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
        public IActionResult CheckIfCartExists(string userName)
        {
            var response = this._cartService.CheckIfCartExists(userName);

            if (response == false)
            {
                return Ok(false);
                
            }

            return Ok(true);

        }

        [HttpPost("/api/Cart/create")]
        public IActionResult CreateCart([FromBody] CreateCartModel cartModel)
        {
            var result = _cartService.CreateCart(cartModel);

            if (result != 1)
            {
                return BadRequest("Failed to create cart.");
            }

            return Ok("Successfully created cart.");
        }

        [HttpPut("/api/Cart/update")]
        public IActionResult UpdateCart([FromBody] EditCartModel cartModel)
        {
            var result = _cartService.UpdateCart(cartModel);

            if (result == 0)
            {
                return BadRequest("Failed to update cart.");
            }

            return Ok("Successfully updated cart.");
        }

        [HttpDelete("/api/Cart/{id}")]
        public IActionResult DeleteCart([FromBody] int cartId)
        {
            var result = _cartService.DeleteCart(cartId);

            if (result != 1)
            {
                return BadRequest("Failed to delete cart.");
            }

            return Ok("Successfully delete cart.");
        }

        [HttpGet("/api/Cart/GetCartItem/{cartItem}")]
        public IActionResult GetCartItems(string userName)
        {
            var cartsItem = _cartService.GetCartItems(userName);

            if (cartsItem == null)
            {
                return BadRequest("Failed to fetch cart items or no cart items in the cart.");
            }

            return Ok(cartsItem);
        }

        [HttpGet("/api/Cart/GetCartByUserName/{userName}")]
        public IActionResult GetUserCart(string userName)
        {
            var carts = _cartService.GetUserCart(userName);

            if (carts == null)
            {
                return BadRequest("Failed to fetch carts or no carts connected with this user in the database.");
            }

            return Ok(carts);
        }
    }
}
