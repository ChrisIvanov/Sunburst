namespace Sunburst.Data.Models.Shop
{
    public class History
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public IEnumerable<Cart>? PastPurchases { get; set; }

        public IEnumerable<Item>? ItemsReviewed { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
    }
}
