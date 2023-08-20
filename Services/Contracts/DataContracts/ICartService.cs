namespace Sunburst.Services.Contracts.DataContracts
{
    using Sunburst.Models.Shop.Cart;
    using Sunburst.Models.Shop.Cart.CartItem;
    using System.Threading.Tasks;

    public interface ICartService
    {
        bool CheckIfCartExists(string userName);

        int CreateCart(CreateCartModel modelItem);

        int UpdateCart(EditCartModel modelItem);

        int DeleteCart(int cartId);

        GetCartModel GetUserCart(string userName);

        IEnumerable<GetCartItemModel> GetCartItems(string userName);
    }
}
