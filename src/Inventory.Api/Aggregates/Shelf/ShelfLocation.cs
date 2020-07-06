using System;

namespace Inventory.Api.Aggregates.Shelf
{
    public class ShelfLocation
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Position { get; set; }
    }
}
