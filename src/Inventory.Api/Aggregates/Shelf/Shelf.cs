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

        public void SetShelfProducts(List<int> productIds, int row, int position)
        {
            ShelfProducts.Clear();
            foreach (var productId in productIds)
            {
                ShelfProducts.Add(new ShelfProduct(productId, row, position));
            }
        }

        public void DeleteShelfProduct(ShelfProduct shelfProduct)
        {
            ShelfProducts.Remove(shelfProduct);
        }

        private List<ShelfProduct> GetExistingShelfProducts(int row, int column)
        {
            return ShelfProducts.Where(x => x.Row == row && x.Column == column).ToList();
        }

        public ShelfInfo ShelfInfo { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }
        public virtual ICollection<ShelfProduct> ShelfProducts {get; set;}
    }
}
