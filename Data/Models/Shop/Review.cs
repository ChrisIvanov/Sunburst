namespace Sunburst.Data.Models.Shop
{
    public class Review
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string? ReviewDescr { get; set; }

        public int ReviewRating { get; set; }

        public DateTime PostedDate { get; set; }
    }
}
