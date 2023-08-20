namespace Sunburst.Data.Models.Shop
{
    public class CartItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public int CartId { get; set; }
    }
}
