namespace Sunburst.Services.DataService
{
    using Sunburst.Data.Models.Shop;
    using Sunburst.Data;
    using Sunburst.Models.Shop.Item;
    using Sunburst.Models.Shop.Set;
    using System.Net;

    public class SetService
    {
        private SunburstDbContext _context;
        private readonly List<GetSetModel> setModels;

        public SetService()
        {
            this.setModels = new List<GetSetModel>();
        }

        public async Task<int> CreateSetAsync(CreateSetModel modelSet)
        {
            var match = this._context.Sets.Where(x => x.Name == modelSet.Name);

            if (match != null)
            {
                throw new Exception("Set already exists.");
            }

            Set set = new Set();

            set.Name = modelSet.Name;
            set.Description = modelSet.Description;
            set.ItemsCount = modelSet.ItemsCount;

            if (modelSet.Items != null)
            {
                var modelSetItems = new List<Item>();
                foreach (var item in set.Items)
                {
                    Item itemModel = new Item();

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

                    modelSetItems.Add(itemModel);
                }

                set.Items = modelSetItems;
            }

            await this._context.Sets.AddAsync(set);
            var result = await this._context.SaveChangesAsync();

            if (result != 1)
            {
                throw new Exception("Could not load set into database. Please try again.");
            }

            return 1;
        }

        public async Task<int> EditSetAsync(EditSetModel modelSet)
        {
            var set = this._context.Sets.Where(x => x.Name == modelSet.Name).Single();

            Set newSet = new Set();

            set.Name = modelSet.Name;
            set.Description = modelSet.Description;
            set.ItemsCount = modelSet.ItemsCount;

            if (modelSet.Items != null)
            {
                var modelSetItems = new List<Item>();
                foreach (var item in set.Items)
                {
                    Item itemModel = new Item();

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

                    modelSetItems.Add(itemModel);
                }

                set.Items = modelSetItems;
            }

            this._context.Update(set);
            var result = await this._context.SaveChangesAsync();

            if (result != 1)
            {
                throw new Exception("Could not load item into database. Please try again.");
            }

            return 1;
        }

        public IEnumerable<GetSetModel> GetAllSets()
        {
            var allSets = _context.Sets;

            foreach (var set in allSets)
            {
                GetSetModel newSet = new GetSetModel();

                set.Name = newSet.Name;
                set.Description = newSet.Description;
                set.ItemsCount = newSet.ItemsCount;

                if (set.Items != null)
                {
                    var modelSetItems = new List<Item>();
                    foreach (var item in set.Items)
                    {
                        Item itemModel = new Item();

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

                        modelSetItems.Add(itemModel);
                    }

                    set.Items = modelSetItems;
                }

                setModels.Add(newSet);
            }

            return setModels;
        }

        public GetSetModel GetSetByName(string name)
        {
            var set = this._context.Sets.Single(x => x.Name == name);

            GetSetModel setModel = new GetSetModel();

            setModel.Name = set.Name;
            setModel.Description = set.Description;
            setModel.ItemsCount = set.ItemsCount;

            if (setModel.Items != null)
            {
                var modelSetItems = new List<Item>();
                foreach (var item in set.Items)
                {
                    Item itemModel = new Item();

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

                    modelSetItems.Add(itemModel);
                }

                set.Items = modelSetItems;
            }

            return setModel;
        }

        public void DeleteItemAsync(string name)
        {
            var set = this._context.Sets.Where(x => x.Name == name);

            if (set == null)
            {
                throw new Exception("Set not found!");
            }

            this._context.Remove(set);
            this._context.SaveChanges();

        }
    }
}
