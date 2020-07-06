using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates.Shelf;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mapper
{
    public class ShelfLocationMapper
    {
        public ShelfLocationModel Map(ShelfLocation source)
        {
            return new ShelfLocationModel
            {
                Id = source.Id,
                Row = source.Row,
                Position = source.Position
            };
        }

        public List<ShelfLocationModel> Map(List<ShelfLocation> source)
        {
            return source.Select(x => Map(x)).ToList();
        }
    }
}
