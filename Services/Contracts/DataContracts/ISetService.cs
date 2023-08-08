namespace Sunburst.Services.Contracts.DataContracts
{
    using Sunburst.Models.Shop.Set;

    public interface ISetService
    {
        Task<int> CreateSetAsync(CreateSetModel modelSet);
        
        Task<int> EditSetAsync(EditSetModel modelSet);
        
        IEnumerable<GetSetModel> GetAllSets();
        
        GetSetModel GetSetByName(string name);
        
        void DeleteItemAsync(string name);
    }
}
