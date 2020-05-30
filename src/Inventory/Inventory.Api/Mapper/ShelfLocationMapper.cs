using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates.Shelf;
using Plato.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ag2yd.Inventory.Api.Mapper
{
    public class ShelfLocationMapper : MapperBase, IShelfLocationMapper
    {
        public async Task MapAsync(ShelfLocation source, ShelfLocationModel target, params object[] args)
        {
            target.Id = source.Id;
            target.Row = source.Row;
            target.Position = source.Position;
        }

        public async Task MapAsync(IEnumerable<ShelfLocation> source, List<ShelfLocationModel> target, params object[] args)
        {
            foreach (var entity in source)
            {
                target.Add(await MapAsync<ShelfLocation, ShelfLocationModel>(entity));
            }
        }
    }
}
