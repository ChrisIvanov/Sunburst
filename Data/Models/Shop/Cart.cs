namespace Sunburst.Data.Models.Shop
{
    public class Cart
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public decimal TotalPrice { get; set; }

        public string? DeliveryDate { get; set; }

        public IEnumerable<CartItem>? Items { get; set; }

        public DateTime? Created { get; set; }

        public bool Edited { get; set; }
    }
}
