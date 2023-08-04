namespace Sunburst.Models.Shop.History
{
    using Sunburst.Data.Models.Shop;
    using Sunburst.Models.Shop.Item;
    using System.ComponentModel.DataAnnotations;

    public class CreateHistoryModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public IEnumerable<GetHistoryModel>? PastPurchases { get; set; }

        [Required]
        public IEnumerable<GetItemModel>? ItemsReviewed { get; set; }

        [Required]
        public IEnumerable<Review>? Reviews { get; set; }
    }
}
