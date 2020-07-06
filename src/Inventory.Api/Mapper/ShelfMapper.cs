using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates.Shelf;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mapper
{
    public class ShelfMapper
    {
        public ShelfModel Map(Shelf source)
        {
            return new ShelfModel
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                ShelfLocations = new ShelfLocationMapper().Map(source.ShelfLocations)
            };
        }

        public List<ShelfModel> Map(List<Shelf> source)
        {
            return source.Select(x => Map(x)).ToList();
        }
    }
}
