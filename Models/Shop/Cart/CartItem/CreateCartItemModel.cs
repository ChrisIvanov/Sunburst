﻿namespace Sunburst.Models.Shop.Cart.CartItem
{
    public class CreateCartItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public int CartId { get; set; }
    }
}
