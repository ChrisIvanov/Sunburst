namespace Sunburst.Services.DataService
{
    using Microsoft.EntityFrameworkCore;
    using Sunburst.Data;
    using Sunburst.Data.Models.Shop;
    using Sunburst.Models.Shop.Cart;
    using Sunburst.Models.Shop.Cart.CartItem;
    using Sunburst.Models.Shop.Item;
    using Sunburst.Services.Contracts.DataContracts;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CartService : ICartService
    {
        private readonly SunburstDbContext _context;
        private readonly List<CartItem> cartItems;
        private readonly List<GetCartModel> cartList;
        private readonly List<GetCartItemModel> cartItemList;

        public CartService(SunburstDbContext context)
        {
            this._context = context;
            this.cartItems = new List<CartItem>();
            this.cartList = new List<GetCartModel>();
            this.cartItemList = new List<GetCartItemModel>();
        }

        public async Task<bool> CheckIfCartExists(string userName)
        {
            var cartExists = await this._context.Carts
                .Where(c => c.UserName == userName & c.Created == DateTime.Now.AddMinutes(-30))
                .SingleOrDefaultAsync();

            if (cartExists == null) 
            {
                return false;
            }

            return true;
        }

        public async Task<int> CreateCartAsync(CreateCartModel cartModel)
        {
            var cart = new Cart();

            cart.UserName = cartModel.UserName;
            cart.TotalPrice = cartModel.TotalPrice;
            cart.Items = null;

            await this._context.Carts.AddAsync(cart);
            await this._context.SaveChangesAsync();

            cart.Items = MapModelToCartItems(cartModel.Items);

            this._context.Carts.Update(cart);
            return await this._context.SaveChangesAsync();
        }

        public async Task<int> UpdateCartAsync(EditCartModel modelItem)
        {
            var cart = await this._context.Carts
                .Where(c => c.UserName == modelItem.UserName)
                .OrderByDescending(c => c.Created)
                .SingleOrDefaultAsync();

            cartItems.Clear();

            if (cart != null)
            {
                cart.UserName = modelItem.UserName;
                cart.TotalPrice = modelItem.TotalPrice;
                cart.DeliveryDate = modelItem.DeliveryDate.ToString();
                cart.Created = modelItem.Created;
                cart.Edited = modelItem.Edited;

                foreach (var newCartItem in modelItem.Items)
                {
                    var cartItem = new CartItem();

                    cartItem.Price = newCartItem.Price;
                    cartItem.ItemName = newCartItem.ItemName;
                    cartItem.ImagePath = newCartItem.ImagePath;
                    cartItem.CartId = newCartItem.CartId;

                    cartItems.Add(cartItem);
                }

                cart.Items = cartItems;

                this._context.Carts.Update(cart);
                return await this._context.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<int> DeleteCartAsync(int cartId)
        {
            var cart = await this._context.Carts.Where(c => c.Id == cartId).SingleOrDefaultAsync();

            if (cart != null) 
            {
                this._context.Remove(cart);
                return await this._context.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<IEnumerable<GetCartModel>> GetAllCartsAsync()
        {
            var allCarts = await this._context.Carts.ToListAsync();

            if (allCarts.Count > 0)
            {
                var cartList = MapCartToModel(allCarts);

                return cartList;
            }

            return null;
        }

        public async Task<IEnumerable<GetCartItemModel>?> GetCartItems(string userName)
        {
            var cart = await this._context.Carts
                .Where(c => c.UserName == userName)
                .OrderByDescending(c => c.Created)
                .SingleOrDefaultAsync();

            if (cart != null)
            {
                var cartItems = await this._context.CartItems.Where(x => x.Id == cart.Id).ToListAsync();

                if (cartItems != null)
                {
                    foreach (var cartItem in cartItems)
                    {
                        var cartItemModel = new GetCartItemModel();

                        cartItemModel.CartId = cart.Id;
                        cartItemModel.Price = cartItem.Price;
                        cartItemModel.ItemName = cartItem.ItemName;
                        cartItemModel.ImagePath = cartItem.ImagePath;

                        cartItemList.Add(cartItemModel);
                    }
                }

                return cartItemList;
            }

            return null;
        }

        public async Task<IEnumerable<GetCartModel>> GetCartsByUserName(string userName)
        {
            var userCarts = await this._context.Carts.Where(x => x.UserName == userName).ToListAsync();

            var userCartModels = MapCartToModel(userCarts);

            return userCartModels;
        }

        private List<CartItem> MapModelToCartItems(IEnumerable<GetCartItemModel> cartItemList)
        {
            var latestCart = _context.Carts.OrderByDescending(c => c.Created).FirstOrDefault();
            var itemCartList = new List<CartItem>();

            foreach (var item in cartItemList)
            {
                var cartItem = new CartItem();
                cartItem.ItemName = item.ItemName;
                cartItem.Price = item.Price;
                cartItem.ImagePath = item.ImagePath;
                cartItem.CartId = latestCart.Id;

                itemCartList.Add(cartItem);
            }

            return itemCartList;
        }


        private List<GetCartItemModel> MapCartItemsToModel(IEnumerable<CartItem> cartItemList)
        {
            var latestCart = _context.Carts.OrderByDescending(c => c.Created).FirstOrDefault();
            var itemCartList = new List<GetCartItemModel>();

            if (cartItemList != null)
            {
                foreach (var item in cartItemList)
                {
                    var cartItem = new GetCartItemModel();
                    cartItem.ItemName = item.ItemName;
                    cartItem.Price = item.Price;
                    cartItem.ImagePath = item.ImagePath;
                    cartItem.CartId = latestCart.Id;

                    itemCartList.Add(cartItem);
                }
            }

            return itemCartList;
        }

        private List<GetCartModel> MapCartToModel(List<Cart> allCarts)
        {
            cartList.Clear();

            if (allCarts != null)
            {
                foreach (var cart in allCarts)
                {
                    var cartModel = new GetCartModel();

                    cartModel.UserName = cart.UserName;
                    cartModel.Items = this.MapCartItemsToModel(cart.Items);
                    cartModel.TotalPrice = cart.TotalPrice;
                    cartModel.Created = cart.Created;
                    cartModel.Edited = cart.Edited;

                    cartList.Add(cartModel);
                }
            }

            return cartList;
        }

    }
}
