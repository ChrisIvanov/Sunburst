namespace Sunburst.Models.Shop.Cart
{
    using Sunburst.Models.Shop.Cart.CartItem;
    using System.ComponentModel.DataAnnotations;

    public class EditCartModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public decimal TotalPrice { get; set; }

        public string DeliveryDate { get; set; }

        public string? Created { get; set; }

        public IEnumerable<GetCartItemModel>? Items { get; set; }

        public bool Edited { get; set; }
    }
}
