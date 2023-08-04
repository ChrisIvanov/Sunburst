namespace Sunburst.Models.Shop.Cart
{
    using Sunburst.Models.Shop.Item;

    public class GetCartModel
    {
        public string UserId { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime DeliveryDate { get; set; } = DateTime.Now.AddDays(3);

        public IEnumerable<GetItemModel>? Items { get; set; }

        public DateTime? Created { get; set; }

        public bool Edited { get; set; }
    }
}
