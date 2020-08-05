using Inventory.Api.SeedWork;

namespace Inventory.Api.Aggregates.Shelf
{
    public class ShelfLocation : Entity
    {
        public ShelfLocation() { }

        public ShelfLocation(int row, int position) 
        {
            Row = row;
            Position = position;
        }

        public int Row { get; private set; }
        public int Position { get; private set; }
    }
}
