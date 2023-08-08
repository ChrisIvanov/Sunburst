namespace Sunburst.Services.DataService
{
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.EntityFrameworkCore;
    using Sunburst.Data;
    using Sunburst.Data.Models.Shop;
    using Sunburst.Models.Shop.Item;
    using Sunburst.Services.Contracts.DataContracts;

    public class ItemService : IItemService
    {
        private readonly SunburstDbContext _context;
        private readonly List<GetItemModel> itemList;

        public ItemService(SunburstDbContext context)
        {
            _context = context;
            this.itemList = new List<GetItemModel>();
        }

        public async Task<int> CreateItemAsync(CreateItemModel itemModel)
        {
            var match = await this._context.Items.AnyAsync(x => x.Name == itemModel.Name);

            if (!match)
            {
                throw new NullReferenceException("Item already exists.");
            }

            Item item = new Item();

            item.Name = itemModel.Name;
            item.Description = itemModel.Description;
            item.Price = itemModel.Price;
            item.Availability = itemModel.Availability;
            item.ImagePath = itemModel.ImagePath;
            item.OverallRating = itemModel.OverallRating;
            item.Category = itemModel.Category;
            if (itemModel.HasSet)
            {
                item.HasSet = true;
                item.SetId = itemModel.SetId;
            }

            await this._context.Items.AddAsync(item);
            var resilt = await this._context.SaveChangesAsync();

            return resilt;
        }

        public async Task<int> UpdateItemAsync(EditItemModel itemModel)
        {
            var item = await this._context.Items.Where(x => x.Name == itemModel.Name).SingleAsync();

            item.Name = itemModel.Name;
            item.Description = itemModel.Description;
            item.Price = itemModel.Price;
            item.Availability = itemModel.Availability;
            item.ImagePath = itemModel.ImagePath;
            item.OverallRating = itemModel.OverallRating;
            item.Category = itemModel.Category;
            if (item.HasSet)
            {
                item.HasSet = true;
                item.SetId = itemModel.SetId;
            }

            this._context.Update(item);
            var result = await this._context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<GetItemModel>> GetAllItemsAsync()
        {
            var allItems = await _context.Items.ToListAsync();

            foreach (var item in allItems)
            {
                GetItemModel itemModel = new GetItemModel();

                itemModel.Name = item.Name;
                itemModel.Description = item.Description;
                itemModel.Price = item.Price;
                itemModel.Availability = item.Availability;
                itemModel.ImagePath = item.ImagePath;
                itemModel.OverallRating = item.OverallRating;
                itemModel.Category = item.Category;
                if (item.HasSet)
                {
                    itemModel.HasSet = true;
                    itemModel.SetId = item.SetId;
                }

                itemList.Add(itemModel);
            }

            return itemList;
        }

        public async Task<GetItemModel> GetItemByName(string name)
        {
            var item = await _context.Items.SingleAsync(x => x.Name == name);

            GetItemModel itemModel = new GetItemModel();

            itemModel.Name = item.Name;
            itemModel.Description = item.Description;
            itemModel.Price = item.Price;
            itemModel.Availability = item.Availability;
            itemModel.ImagePath = item.ImagePath;
            itemModel.OverallRating = item.OverallRating;
            itemModel.Category = item.Category;
            if (item.HasSet)
            {
                itemModel.HasSet = true;
                itemModel.SetId = item.SetId;
            }

            return itemModel;
        }

        public async Task<IEnumerable<GetItemModel>> GetItemsByCategory(string category)
        {
            var items = await _context.Items.Where(x => x.Category == category).ToListAsync();

            foreach (var item in items)
            {
                GetItemModel itemModel = new GetItemModel();

                itemModel.Name = item.Name;
                itemModel.Description = item.Description;
                itemModel.Price = item.Price;
                itemModel.Availability = item.Availability;
                itemModel.ImagePath = item.ImagePath;
                itemModel.OverallRating = item.OverallRating;
                itemModel.Category = item.Category;
                if (item.HasSet)
                {
                    itemModel.HasSet = true;
                    itemModel.SetId = item.SetId;
                }

                itemList.Add(itemModel);
            }

            return itemList;
        }

        public async Task<int> DeleteItemAsync(string name)
        {
            var item = await this._context.Items.Where(x => x.Name == name).SingleAsync();

            if (item == null)
            {
                throw new Exception("Item not found!");
            }

            this._context.Remove(item);
            var result = await this._context.SaveChangesAsync();

            return result;
        }
    }
}
