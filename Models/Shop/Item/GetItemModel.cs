namespace Sunburst.Models.Shop.Item
{
    public class GetItemModel
    {
        public string? Name { get; set; }

        public bool Availability { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public bool HasSet { get; set; }

        public int SetId { get; set; }

        public string? ImagePath { get; set; }

        public int OverallRating { get; set; }

        public string? Category { get; set; }
    }
}
