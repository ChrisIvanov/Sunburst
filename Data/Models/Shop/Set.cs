namespace Sunburst.Data.Models.Shop
{
    public class Set
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int ItemsCount { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
