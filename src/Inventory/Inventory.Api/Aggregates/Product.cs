using Inventory.Api.Aggregates.Shelf;
using System;

namespace Inventory.Api.Aggregates
{
    public class Product
    {
        public string Upc { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExpirationLocation { get; set; }
        public string ImageUrl { get; set; }
        public int OunceWeight { get; set; }

        public bool RequiresPadding { get; set; }
        public bool RequiresBubbleWrap { get; set; }
        public Guid ShelfLocationId { get; set; }

        public ShelfLocation ShelfLocation { get; set; }
    }
}
