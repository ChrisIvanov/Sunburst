namespace Sunburst.Models.Shop.Item
{
    using Sunburst.Data.Models.Shop;
    using System.ComponentModel.DataAnnotations;

    public class CreateItemModel
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public bool HasSet { get; set; }

        [Required]
        public int SetId { get; set; }

        [Required]
        public string? ImagePath { get; set; }

        [Required]
        public int OverallRating { get; set; }

        [Required]
        public string? Category { get; set; }
    }
}
