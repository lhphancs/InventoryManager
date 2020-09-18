using System;

namespace Inventory.Abstraction.Dto
{
    public class ShelfProductDto
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Position { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }
    }
}
