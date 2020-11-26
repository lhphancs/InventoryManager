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
            UpdateShelfInfo(shelfInfoDto);
        }

        public void UpdateShelfInfo(ShelfInfoDto shelfInfoDto)
        {
            ShelfInfo = new ShelfInfo(shelfInfoDto);

            ModifiedDateTime = CreatedDateTime;
        }

        public void AddShelfProduct(int productId, int row, int position)
        {
            if (GetExistingShelfProduct(row, position) != null)
            {
                throw new InvalidOperationException($"ShelfId '{Id}' already has a shelfProduct at row={row} position={position}");
            }

            var shelfProduct = new ShelfProduct(productId, row, position);
            ShelfProducts.Add(shelfProduct);
        }

        public void DeleteShelfProduct(ShelfProduct shelfProduct)
        {
            ShelfProducts.Remove(shelfProduct);
        }

        private ShelfProduct GetExistingShelfProduct(int row, int position)
        {
            return ShelfProducts.FirstOrDefault(x => x.Row == row && x.Position == position);
        }

        public ShelfInfo ShelfInfo { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }
        public virtual ICollection<ShelfProduct> ShelfProducts {get; set;}
    }
}
