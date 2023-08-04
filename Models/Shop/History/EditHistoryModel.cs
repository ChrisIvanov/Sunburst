namespace Sunburst.Models.Shop.History
{
    using Sunburst.Data.Models.Shop;
    using System.ComponentModel.DataAnnotations;

    public class EditHistoryModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public IEnumerable<Cart>? PastPurchases { get; set; }

        [Required]
        public IEnumerable<Item>? ItemsReviewed { get; set; }

        [Required]
        public IEnumerable<Review>? Reviews { get; set; }
    }
}
