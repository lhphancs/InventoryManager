using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure.EntityConfigurations.ManyToManyClasses;
using Inventory.Api.SeedWork;
using Inventory.Api.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddProduct(int productId)
        {
            ProductWholesalers.Add(new ProductWholesaler
            {
                ProductId = productId,
                WholesalerId = Id
            });
            ModifiedDateTime = DateTime.UtcNow;
        }

        public void DeleteProduct(int productId)
        {
            var productWholesaler = ProductWholesalers.FirstOrDefault(x => x.ProductId == productId);
            if (productWholesaler == null)
            {
                throw new Exception($"ProductId '{productId}' not found in wholesalerId '{Id}'");
            }
            ProductWholesalers.Remove(productWholesaler);
        }

        public WholesalerInfo WholesalerInfo { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }

        public virtual ICollection<ProductWholesaler> ProductWholesalers { get; private set; }
    }
}
