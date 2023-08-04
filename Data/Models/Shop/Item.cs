namespace Sunburst.Data.Models.Shop
{
    using AutoMapper.Configuration.Conventions;
    using System.Reflection.Metadata.Ecma335;

    public class Item
    {
        public int Id { get; set; }

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
