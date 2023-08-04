namespace Sunburst.Models.Shop.Review
{
    using System.ComponentModel.DataAnnotations;

    public class CreateReviewModel
    {
        [Required]
        public int ItemId { get; set; }

        [Required]
        public string? ReviewDescr { get; set; }

        [Required]
        public int ReviewRating { get; set; }

        [Required]
        public DateTime PostedDate { get; set; }
    }
}
