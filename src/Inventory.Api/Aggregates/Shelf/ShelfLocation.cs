using System;

namespace Inventory.Api.Aggregates.Shelf
{
    public class ShelfLocation
    {
        public ShelfLocation() { }

        public Guid Id { get; private set; }
        public int Row { get; private set; }
        public int Position { get; private set; }
    }
}
