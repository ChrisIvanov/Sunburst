namespace Sunburst.Models.Shop
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

        public bool IsSet { get; set; }

        public int SetId { get; set; }

        public Set Set { get; set; }

        public string? ImagePath { get; set; }
    }
}
