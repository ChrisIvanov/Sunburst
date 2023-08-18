namespace Sunburst.Models.Shop.Cart
{
    using Sunburst.Models.Shop.Cart.CartItem;
    using System.ComponentModel.DataAnnotations;

    public class EditCartModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime? Created { get; set; }

        public IEnumerable<GetCartItemModel>? Items { get; set; }

        public bool Edited { get; set; }
    }
}
