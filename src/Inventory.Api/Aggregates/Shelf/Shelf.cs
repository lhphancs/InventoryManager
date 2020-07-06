using System;
using System.Collections.Generic;

namespace Inventory.Api.Aggregates.Shelf
{
    public class Shelf
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ShelfLocation > ShelfLocations {get; set;}
    }
}
