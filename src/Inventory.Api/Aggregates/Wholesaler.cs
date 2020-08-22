using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure.EntityConfigurations.ManyToManyClasses;
using Inventory.Api.SeedWork;
using Inventory.Api.ValueObjects;
using System;
using System.Collections.Generic;

namespace Inventory.Api.Aggregates
{
    public class Wholesaler : Entity
    {
        public Wholesaler() { }

        public Wholesaler(WholesalerInfoDto wholesalerInfoDto)
        {
            UpdateWholesalerInfo(wholesalerInfoDto);

            CreatedDateTime = DateTime.UtcNow;
            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateWholesalerInfo(WholesalerInfoDto wholesalerInfoDto)
        {
            WholesalerInfo = new WholesalerInfo(wholesalerInfoDto);

            ModifiedDateTime = CreatedDateTime;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            ModifiedDateTime = DateTime.UtcNow;
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public WholesalerInfo WholesalerInfo { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }

        public virtual ICollection<Product> Products { get; private set; }
        public virtual ICollection<ProductWholesaler> ProductWholesalers { get; private set; }
    }
}
