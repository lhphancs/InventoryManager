using Inventory.Abstraction.Dto;
using Inventory.Api.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Aggregates.Shelf
{
    public class Shelf : Entity
    {
        public Shelf() { }

        public Shelf(ShelfDto shelfDto) 
        {
            Name = shelfDto.Name;
            Description = shelfDto.Description;
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

        private ShelfLocation GetExistingShelfLocation(int row, int position)
        {
            return ShelfLocations.FirstOrDefault(x => x.Row == row && x.Position == position);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public virtual List<ShelfLocation> ShelfLocations {get; set;}
    }
}
