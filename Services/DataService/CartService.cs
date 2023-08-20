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
    using System.Linq;
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

        public bool CheckIfCartExists(string userName)
        {
            var cartExists = this._context.Carts
                .Where(c => c.UserName == userName)
                .OrderByDescending(c => c.Created)
                .First();

            if (cartExists == null)
            {
                return false;
            }

            return true;
        }

        public int CreateCart(CreateCartModel cartModel)
        {
            var cart = new Cart();

            cart.UserName = cartModel.UserName;
            cart.TotalPrice = cartModel.TotalPrice;
            cart.Created = cartModel.Created;
            cart.DeliveryDate = cartModel.DeliveryDate.ToString();

            this._context.Carts.AddAsync(cart);
            this._context.SaveChangesAsync();

            var items = MapModelToCartItems(cartModel.Items);
            cart.Items = items;

            this._context.Carts.Update(cart);
            return this._context.SaveChanges();
        }

        public int UpdateCart(EditCartModel modelItem)
        {
            var cart =  this._context.Carts
                .Where(c => c.UserName == modelItem.UserName)
                .OrderByDescending(c => c.Created)
                .FirstOrDefault();

            cartItems.Clear();

            var totalPrice = 0m;

            if (cart != null)
            {
                cart.UserName = modelItem.UserName;

                cart.DeliveryDate = modelItem.DeliveryDate.ToString();

                cart.Edited = modelItem.Edited;

                foreach (var newCartItem in modelItem.Items)
                {
                    var cartItem = new CartItem();
                    var itemInCart = new ItemInCart();

                    cartItem.Price = newCartItem.Price;
                    cartItem.Name = newCartItem.Name;
                    cartItem.ImagePath = newCartItem.ImagePath;
                    cartItem.CartId = newCartItem.CartId;

                    totalPrice += newCartItem.Price;

                    cartItems.Add(cartItem);


                    itemInCart.CartId = newCartItem.CartId;
                    itemInCart.ItemId = this._context.Items
                        .Where(i => i.Name == cartItem.Name)
                        .Select(i => i.Id)
                        .FirstOrDefault();

                   this._context.ItemsInCarts.Add(itemInCart);
                }

                cart.TotalPrice = totalPrice;

                cart.Items = cartItems;

                this._context.Carts.Update(cart);
                return this._context.SaveChanges();
            }

            return 0;
        }

            public int DeleteCart(int cartId)
        {
            var cart =  this._context.Carts.Where(c => c.Id == cartId).SingleOrDefault();

            if (cart != null)
            {
                this._context.Remove(cart);
                return this._context.SaveChanges();
            }

            return 0;
        }

        public IEnumerable<GetCartItemModel> GetCartItems(string userName)
        {
            var cart = this._context.Carts
                .Where(c => c.UserName == userName)
                .OrderByDescending(c => c.Created)
                .SingleOrDefault();

            if (cart != null)
            {
                var cartItems = this._context.CartItems.Where(x => x.Id == cart.Id).ToList();

                if (cartItems != null)
                {
                    foreach (var cartItem in cartItems)
                    {
                        var cartItemModel = new GetCartItemModel();

                        cartItemModel.CartId = cart.Id;
                        cartItemModel.Price = cartItem.Price;
                        cartItemModel.Name = cartItem.Name;
                        cartItemModel.ImagePath = cartItem.ImagePath;

                        cartItemList.Add(cartItemModel);
                    }
                }

                return cartItemList;
            }

            return null;
        }

        public GetCartModel GetUserCart(string userName)
        {
            var userCarts = this._context.Carts.Where(x => x.UserName == userName)
                .OrderByDescending(c => c.Created)
                .First();

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
                cartItem.Name = item.Name;
                cartItem.Price = item.Price;
                cartItem.ImagePath = item.ImagePath;
                cartItem.CartId = latestCart.Id;

                itemCartList.Add(cartItem);
            }

            return itemCartList;
        }

        //private async Task<List<GetCartItemModel>> AddItemToCart(IEnumerable<GetCartItemModel> cartItemList)
        //{
        //    var latestCart = await _context.Carts.OrderByDescending(c => c.Created).FirstOrDefaultAsync();
        //    var itemCartList = new List<GetCartItemModel>();

        //    if (cartItemList != null)
        //    {
        //        foreach (var item in cartItemList)
        //        {
        //            var cartItem = new GetCartItemModel();
        //            cartItem.ItemName = item.ItemName;
        //            cartItem.Price = item.Price;
        //            cartItem.ImagePath = item.ImagePath;
        //            cartItem.CartId = latestCart.Id;

        //            itemCartList.Add(cartItem);
        //        }
        //    }

        //    return itemCartList;
        //}


        private List<GetCartItemModel> MapCartItemsToModel(IEnumerable<CartItem> cartItemList)
        {
            var latestCart = _context.Carts.OrderByDescending(c => c.Created).FirstOrDefault();
            var itemCartList = new List<GetCartItemModel>();

            if (cartItemList != null)
            {
                foreach (var item in cartItemList)
                {
                    var cartItem = new GetCartItemModel();
                    cartItem.Name = item.Name;
                    cartItem.Price = item.Price;
                    cartItem.ImagePath = item.ImagePath;
                    cartItem.CartId = latestCart.Id;

                    itemCartList.Add(cartItem);
                }
            }

            return itemCartList;
        }

        private GetCartModel MapCartToModel(Cart cart)
        {
            var cartModel = new GetCartModel();

            if (cart != null)
            {
                cartModel.UserName = cart.UserName;
                cartModel.Items = this.MapCartItemsToModel(cart.Items);
                
                cartModel.Created = cart.Created;
                cartModel.Edited = cart.Edited;

                if (cart.Items == null)
                {
                    cartModel.TotalPrice = 0;
                }
                else
                {
                    cartModel.TotalPrice = cart.Items.Sum(i => i.Price);
                }
            }

            return cartModel;
        }
    }
}
