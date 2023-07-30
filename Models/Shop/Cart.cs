namespace Sunburst.Models.Shop
{
    public class Cart
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public string? DeliveryDate { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
