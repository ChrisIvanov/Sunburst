namespace Sunburst.Services.Contracts.DataContracts
{
    using Sunburst.Models.Shop.Item;
    using System.Threading.Tasks;

    public interface IItemService
    {
        Task<int> CreateItemAsync(CreateItemModel modelItem);

        Task<int> UpdateItemAsync(EditItemModel modelItem);

        Task<IEnumerable<GetItemModel>> GetAllItemsAsync();

        Task<GetItemModel> GetItemByName(string name);

        Task<IEnumerable<GetItemModel>> GetItemsByCategory(string category);
        
        Task<int> DeleteItemAsync(string name);
    }
}
