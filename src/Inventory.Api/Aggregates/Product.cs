using Inventory.Abstraction.Dto;
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

        public Product(ProductInfoDto productInfoDto)
        {
            UpdateProductInfo(productInfoDto);

            Quantity = 0;

            CreatedDateTime = DateTime.UtcNow;
            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateProductInfo(ProductInfoDto productInfoDto)
        {
            ProductInfo = new ProductInfo(productInfoDto);

            ModifiedDateTime = DateTime.UtcNow;
        }

        public void RecieveIn(ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            ChangeQuantityAmt(productQuantityChangeInfo.CompanyName, productQuantityChangeInfo.QuantityChangeAmt);
        }

        public void ShipOut(ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            ChangeQuantityAmt(productQuantityChangeInfo.CompanyName, -productQuantityChangeInfo.QuantityChangeAmt);
        }

        private void ChangeQuantityAmt(string companyName, int changeAmt)
        {
            Quantity += changeAmt;

            // Send msg to store in audit table
            ModifiedDateTime = CreatedDateTime;

            AddDomainEvent(new ProductQuantityChangeEvent(Id, companyName, changeAmt, DateTime.UtcNow));
        }

        public ProductInfo ProductInfo { get; private set; }

        public int Quantity { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }

        public virtual ICollection<ProductWholesaler> ProductWholesalers { get; private set; }
    }
}
