using System;

namespace Inventory.Abstraction.Models
{
    public class ShelfLocationModel
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Position { get; set; }
    }
}
