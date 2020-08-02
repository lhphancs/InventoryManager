using System;

namespace Inventory.Abstraction.Dto
{
    public class ProductDto
    {
        public string Upc { get; set; }

        public ProductInfoDto ProductInfoDto { get; set; }
        public ProductPreparationInfoDto ProductPreparationInfoDtorationInfo { get; set; }
        public int Quantity { get; set; }
        public Guid? ShelfLocationId { get; set; }
        public ShelfLocationDto? ShelfLocation { get; set; }
    }
}
