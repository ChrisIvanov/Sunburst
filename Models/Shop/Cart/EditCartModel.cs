namespace Sunburst.Models.Shop.Cart
{
    using Sunburst.Data.Models.Shop;
    using Sunburst.Models.Shop.Item;
    using System.ComponentModel.DataAnnotations;

    public class EditCartModel
    {
        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; } = DateTime.Now.AddDays(3);

        [Required]
        public IEnumerable<GetItemModel>? Items { get; set; }

        [Required]
        public DateTime? Created { get; set; }

        [Required]
        public bool Edited { get; set; }
    }
}
