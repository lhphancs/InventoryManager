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

        public void AddShelfLocation(int row, int position)
        {
            if (GetExistingShelfLocation(row, position) != null)
            {
                throw new InvalidOperationException($"ShelfId '{Id}' already has a shelfLocation at row={row} position={position}");
            }

            var shelfLocation = new ShelfLocation(row, position);
            ShelfLocations.Add(shelfLocation);
        }

        public void DeleteShelfLocation(ShelfLocation shelfLocation)
        {
            ShelfLocations.Remove(shelfLocation);
        }

        private ShelfLocation GetExistingShelfLocation(int row, int position)
        {
            return ShelfLocations.FirstOrDefault(x => x.Row == row && x.Position == position);
        }

        public ShelfInfo ShelfInfo { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }
        public virtual ICollection<ShelfLocation> ShelfLocations {get; set;}
    }
}
