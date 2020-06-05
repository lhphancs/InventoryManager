using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates.Shelf;
using Plato.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Api.Mapper
{
    public class ShelfMapper : MapperBase, IShelfMapper
    {
        private readonly IShelfLocationMapper _shelfLocationMapper;
        public ShelfMapper(IShelfLocationMapper shelfLocationMapper)
        {
            _shelfLocationMapper = shelfLocationMapper;
        }
        public async Task MapAsync(Shelf source, ShelfModel target, params object[] args)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ShelfLocations = await _shelfLocationMapper.MapAsync<IEnumerable<ShelfLocation>, List<ShelfLocationModel>>(source.ShelfLocations);
    }

        public async Task MapAsync(IEnumerable<Shelf> source, List<ShelfModel> target, params object[] args)
        {
            foreach (var entity in source)
            {
                var model = await MapAsync<Shelf, ShelfModel>(entity);
                target.Add(model);
            }
        }
    }
}
