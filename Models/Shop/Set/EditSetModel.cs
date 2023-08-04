namespace Sunburst.Models.Shop.Set
{
    using Sunburst.Models.Shop.Item;

    public class EditSetModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int ItemsCount { get; set; }

        public IEnumerable<GetItemModel>? Items { get; set; }
    }
}
