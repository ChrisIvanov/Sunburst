namespace Sunburst.Services.Contracts.DataContracts
{
    using Sunburst.Models.Shop.Cart;
    using Sunburst.Models.Shop.Cart.CartItem;
    using System.Threading.Tasks;

    public interface ICartService
    {
        Task<bool> CheckIfCartExists(string userName);

        Task<int> CreateCartAsync(CreateCartModel modelItem);

        Task<int> UpdateCartAsync(EditCartModel modelItem);

        Task<int> DeleteCartAsync(int cartId);

        Task<IEnumerable<GetCartModel>> GetAllCartsAsync();

        Task<IEnumerable<GetCartModel>> GetCartsByUserName(string userName);

        Task<IEnumerable<GetCartItemModel>?> GetCartItems(string userName);
    }
}
