using Inventory.Api.SeedWork;

namespace Inventory.Api.Aggregates.Shelf
{
    public class ShelfProduct : Entity
    {
        public ShelfProduct() { }

        public ShelfProduct(int productId, int row, int column) 
        {
            ProductId = productId;
            Row = row;
            Column = column;
        }
        public int ProductId { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }

        public virtual Product Product { get; private set; }
    }
}
