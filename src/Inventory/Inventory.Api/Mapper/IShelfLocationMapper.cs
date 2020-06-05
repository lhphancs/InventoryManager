using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates.Shelf;
using Plato.Mapper;
using System.Collections.Generic;

namespace Inventory.Api.Mapper
{
    public interface IShelfLocationMapper : IMapperBase,
        IMapperAsync<ShelfLocation, ShelfLocationModel>,
        IMapperAsync<IEnumerable<ShelfLocation>, List<ShelfLocationModel>>
    {
    }
}
