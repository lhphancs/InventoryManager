using System;
using System.Collections.Generic;

namespace Inventory.Api.Aggregates.Shelf
{
    public class Shelf
    {
        public Shelf() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual List<ShelfLocation > ShelfLocations {get; set;}
    }
}
