using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates.Shelf;
using Plato.Mapper;
using System.Collections.Generic;

namespace Inventory.Api.Mapper
{
    public interface IShelfMapper : IMapperBase,
        IMapperAsync<Shelf, ShelfModel>,
        IMapperAsync<IEnumerable<Shelf>, List<ShelfModel>>
    {
    }
}
