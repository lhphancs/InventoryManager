using Inventory.Abstraction.Dto;
using Inventory.Api.SeedWork;
using Inventory.Api.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Aggregates.Shelf
{
    public class Shelf : Entity
    {
        public Shelf() { }

        public Shelf(ShelfInfoDto shelfInfoDto)
        {
            ShelfProducts = new List<ShelfProduct>();
            UpdateShelfInfo(shelfInfoDto);
        }

        public void UpdateShelfInfo(ShelfInfoDto shelfInfoDto)
        {
            ShelfInfo = new ShelfInfo(shelfInfoDto);

            ModifiedDateTime = DateTime.UtcNow;
        }

        public void AddShelfProduct(int productId, int row, int position)
        {
            ShelfProducts.Add(new ShelfProduct(Id, productId, row, position));
        }

        public void DeleteShelfProduct(int productId)
        {
            var shelfProduct = ShelfProducts.FirstOrDefault(x => x.ProductId == productId);
            if (shelfProduct == null)
            {
                throw new Exception($"ProductId '{productId}' not found in shelfProducts '{Id}'");
            }
            ShelfProducts.Remove(shelfProduct);
        }

        public ShelfInfo ShelfInfo { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }
        public virtual ICollection<ShelfProduct> ShelfProducts { get; private set; }
    }
}
