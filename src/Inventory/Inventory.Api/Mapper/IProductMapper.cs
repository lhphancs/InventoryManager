using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates;
using Plato.Mapper;
using System.Collections.Generic;

namespace Ag2yd.Inventory.Api.Mapper
{
    public interface IProductMapper : IMapperBase,
        IMapperAsync<Product, ProductModel>,
        IMapperAsync<IEnumerable<Product>, List<ProductModel>>
    {
    }
}
