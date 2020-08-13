using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using Inventory.Api.Events.DomainEvents;
using Inventory.Api.Infrastructure.EntityConfigurations.ManyToManyClasses;
using Inventory.Api.SeedWork;
using Inventory.Api.ValueObjects;
using System;
using System.Collections.Generic;

namespace Inventory.Api.Aggregates
{
    public class Product : Entity
    {
        public Product() { }

        public Product(ProductDto productDto)
        {
            Upc = productDto.Upc;
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

        public void RecieveIn(ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            ChangeQuantityAmt(productQuantityChangeInfo.CompanyName, productQuantityChangeInfo.QuantityChangeAmt);
        }

        public void ShipOut(ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            ChangeQuantityAmt(productQuantityChangeInfo.CompanyName, -productQuantityChangeInfo.QuantityChangeAmt);
        }


        public void AssignNewShelfLocation(int shelfLocationId)
        {
            ShelfLocationId = shelfLocationId;
        }

        private void ChangeQuantityAmt(string companyName, int changeAmt)
        {
            Quantity += changeAmt;

            // Send msg to store in audit table
            ModifiedDateTime = CreatedDateTime;

            AddDomainEvent(new ProductQuantityChangeEvent(Id, companyName, changeAmt, DateTime.UtcNow));
        }

        public string Upc { get; private set; }
        public ProductInfo ProductInfo { get; private set; }
        public ProductPreparationInfo ProductPreparationInfo { get; private set; }

        public int Quantity { get; private set; }
        public int? ShelfLocationId { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }

        public virtual ShelfLocation ShelfLocation { get; private set; }
        public virtual ICollection<ProductWholesaler> ProductWholesalers { get; private set; }
    }
}
