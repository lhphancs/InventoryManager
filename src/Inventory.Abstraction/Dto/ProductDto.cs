using System;

namespace Inventory.Abstraction.Dto
{
    public class ProductDto
    {
        public string Upc { get; set; }

        public ProductInfoDto ProductInfo { get; set; }
        public ProductPreparationInfoDto ProductPreparationInfo { get; set; }
        public int Quantity { get; set; }
        public Guid? ShelfLocationId { get; set; }
        public ShelfLocationDto? ShelfLocation { get; set; }
    }
}
