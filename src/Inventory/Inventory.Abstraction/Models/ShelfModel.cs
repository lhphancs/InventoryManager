using System;
using System.Collections.Generic;

namespace Inventory.Abstraction.Models
{
    public class ShelfModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ShelfLocationModel> ShelfLocations {get; set;}
    }
}
