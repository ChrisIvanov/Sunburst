namespace Sunburst.Models.Shop.Set
{
    using Sunburst.Models.Shop.Item;
    using System.ComponentModel.DataAnnotations;

    public class CreateSetModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int ItemsCount { get; set; }

        [Required]
        public IEnumerable<GetItemModel>? Items { get; set; }
    }
}
