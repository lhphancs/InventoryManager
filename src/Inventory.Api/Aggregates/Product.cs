using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using System;

namespace Inventory.Api.Aggregates
{
    public class Product
    {
        public Product() { }

        public Product(ProductDto productDto)
        {
            UpdateProductInfo(productDto.ProductInfo);
            UpdateProductPreparationInfo(productDto.ProductPreparationInfo);

            Quantity = productDto.Quantity;

            CreatedDateTime = DateTime.UtcNow;
            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateProductInfo(ProductInfoDto productInfoDto)
        {
            ProductInfo = new ProductInfo(productInfoDto);

            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateProductPreparationInfo(ProductPreparationInfoDto productPreparationInfoDto)
        {
            ProductPreparationInfo = new ProductPreparationInfo(productPreparationInfoDto);

            ModifiedDateTime = CreatedDateTime;
        }

        public void ChangeQuantity(string companyName, int quantityChange)
        {
            Quantity += quantityChange;

            // Send msg to store in audit table
            ModifiedDateTime = CreatedDateTime;
        }

        public void AssignNewShelfLocation(Guid shelfLocationId)
        {
            ShelfLocationId = shelfLocationId;
        }

        public string Upc { get; private set; }
        public ProductInfo ProductInfo { get; private set; }
        public ProductPreparationInfo ProductPreparationInfo { get; private set; }

        public int Quantity { get; private set; }
        public Guid? ShelfLocationId { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }

        public virtual ShelfLocation ShelfLocation { get; private set; }
    }
}
