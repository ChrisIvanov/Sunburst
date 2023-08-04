namespace Sunburst.Services.DataService
{
    using Microsoft.AspNetCore.Http.HttpResults;
    using Microsoft.EntityFrameworkCore;
    using Sunburst.Data;
    using Sunburst.Data.Models.Shop;
    using Sunburst.Models.Shop.Item;

    public class ItemService
    {
        private SunburstDbContext _context;
        private readonly List<GetItemModel> itemModels;

        public ItemService()
        {
            this.itemModels = new List<GetItemModel>();
        }

        public async Task<int> CreateItemAsync(CreateItemModel modelItem)
        {
            var match = this._context.Items.Where(x => x.Name == modelItem.Name);

            if (match != null)
            {
                throw new NullReferenceException("Item already exists.");
            }

            Item item = new Item();

            item.Name = modelItem.Name;
            item.Description = modelItem.Description;
            item.Price = modelItem.Price;
            item.Availability = modelItem.Availability;
            item.ImagePath = modelItem.ImagePath;
            item.OverallRating = modelItem.OverallRating;
            item.Category = modelItem.Category;
            if (item.HasSet)
            {
                item.HasSet = true;
                item.SetId = modelItem.SetId;
            }

            await this._context.Items.AddAsync(item);
            var result = await this._context.SaveChangesAsync();

            if (result != 1)
            {
                throw new NullReferenceException("Could not load item into database. Please try again.");
            }

            return 1;
        }

        public async Task<int> EditItemAsync(EditItemModel modelItem)
        {
            var item = this._context.Items.Where(x => x.Name == modelItem.Name).Single();

            item.Name = modelItem.Name;
            item.Description = modelItem.Description;
            item.Price = modelItem.Price;
            item.Availability = modelItem.Availability;
            item.ImagePath = modelItem.ImagePath;
            item.OverallRating = modelItem.OverallRating;
            item.Category = modelItem.Category;
            if (item.HasSet)
            {
                item.HasSet = true;
                item.SetId = modelItem.SetId;
            }

            this._context.Update(item);
            var result = await this._context.SaveChangesAsync();

            if (result != 1)
            {
                throw new NullReferenceException("Could not load item into database. Please try again.");
            }

            return 1;
        }

        public IEnumerable<GetItemModel> GetAllItems()
        {
            var allItems = _context.Items;

            foreach (var item in allItems)
            {
                GetItemModel itemModel = new GetItemModel();

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

                itemModels.Add(itemModel);
            }

            return itemModels;
        }

        public GetItemModel GetItemByName(string name)
        {
            var item = _context.Items.Single(x => x.Name == name);

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

        public List<GetItemModel> GetItemsByCategory(string category)
        {
            var items = _context.Items.Where(x => x.Category == category);

            foreach (var item in items)
            {
                GetItemModel itemModel = new GetItemModel();

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

                itemModels.Add(itemModel);
            }

            return itemModels;
        }

        public void DeleteItemAsync(string name)
        {
            var item = this._context.Items.Where(x => x.Name == name);

            if (item == null)
            {
                throw new Exception("Item not found!");
            }

            this._context.Remove(item);
            this._context.SaveChanges();
        }
    }
}
