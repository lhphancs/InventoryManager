using Inventory.Api.SeedWork;

namespace Inventory.Api.Aggregates.Shelf
{
    public class ShelfProduct : Entity
    {
        public ShelfProduct() { }

        public ShelfProduct(int productId, int row, int position) 
        {
            ProductId = productId;
            Row = row;
            Position = position;
        }
        public int ProductId { get; private set; }
        public int Row { get; private set; }
        public int Position { get; private set; }

        public virtual Product Product { get; private set; }
    }
}
