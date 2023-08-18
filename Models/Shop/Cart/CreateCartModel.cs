namespace Sunburst.Models.Shop.Cart
{
    using Sunburst.Data.Models.Shop;
    using Sunburst.Models.Shop.Cart.CartItem;
    using Sunburst.Models.Shop.Item;
    using System.ComponentModel.DataAnnotations;

    public class CreateCartModel
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public decimal TotalPrice { get; set; }

        public DateTime? DeliveryDate { get; set; } = DateTime.Now.AddDays(3);

        public DateTime? Created { get; set; } = DateTime.Now;

        [Required]
        public IEnumerable<GetCartItemModel>? Items { get; set; }

        public bool Edited { get; set; } = false;
    }
}
