using Inventory.Api.SeedWork;
using System.Collections.Generic;

namespace Inventory.Api.Aggregates.Shelf
{
    public class Shelf : Entity
    {
        public Shelf() { }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual List<ShelfLocation > ShelfLocations {get; set;}
    }
}
