﻿namespace Sunburst.Models.Shop.Review
{
    public class EditReviewModel
    {
        public int ItemId { get; set; }

        public string? ReviewDescr { get; set; }

        public int ReviewRating { get; set; }

        public DateTime PostedDate { get; set; }
    }
}
