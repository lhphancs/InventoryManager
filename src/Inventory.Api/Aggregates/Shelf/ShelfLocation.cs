using Inventory.Api.SeedWork;

namespace Inventory.Api.Aggregates.Shelf
{
    public class ShelfLocation : Entity
    {
        public ShelfLocation() { }

        public int Row { get; private set; }
        public int Position { get; private set; }
    }
}
