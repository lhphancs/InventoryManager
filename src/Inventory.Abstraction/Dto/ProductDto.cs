using System;

namespace Inventory.Abstraction.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public ProductInfoDto ProductInfo { get; set; }
        public ProductPreparationInfoDto ProductPreparationInfo { get; set; }
        public int Quantity { get; set; }
        public int? ShelfLocationId { get; set; }
        public ShelfLocationDto ShelfLocation { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}
