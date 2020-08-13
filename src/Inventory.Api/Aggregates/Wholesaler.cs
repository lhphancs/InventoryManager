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

        public Wholesaler(Address address)
        {
            Address = address;

            CreatedDateTime = DateTime.UtcNow;
            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;

            ModifiedDateTime = DateTime.UtcNow;
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

        public Address Address { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }

        public virtual ICollection<Product> Products { get; private set; }
        public virtual ICollection<ProductWholesaler> ProductWholesalers { get; private set; }
    }
}
