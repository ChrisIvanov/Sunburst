namespace Sunburst.Models.Shop.Cart.CartItem
{
    public class GetCartItemModel
    {
        public int Id { get; set; }

        public string ItemName { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public int CartId { get; set; }
    }
}
