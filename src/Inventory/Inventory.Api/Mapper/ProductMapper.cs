using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates;
using Inventory.Api.Aggregates.Shelf;
using Plato.Mapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ag2yd.Inventory.Api.Mapper
{
    public class ProductMapper : MapperBase, IProductMapper
    {
        private readonly IShelfLocationMapper _shelfLocationMapper;

        public ProductMapper(IShelfLocationMapper shelfLocationMapper)
        {
            _shelfLocationMapper = shelfLocationMapper;
        }

        public async Task MapAsync(Product source, ProductModel target, params object[] args)
        {
            target.Upc = source.Upc;
            target.Brand = source.Brand;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ExpirationLocation = source.ExpirationLocation;
            target.ImageUrl = source.ImageUrl;
            target.OunceWeight = source.OunceWeight;
            target.RequiresPadding = source.RequiresPadding;
            target.RequiresBubbleWrap = source.RequiresBubbleWrap;
            target.ShelfLocationId = source.ShelfLocationId;
            target.ShelfLocation = await _shelfLocationMapper.MapAsync<ShelfLocation, ShelfLocationModel>(source.ShelfLocation);
        }

        public async Task MapAsync(IEnumerable<Product> source, List<ProductModel> target, params object[] args)
        {
            foreach (var entity in source)
            {
                target.Add(await MapAsync<Product, ProductModel>(entity));
            }
        }
    }
}
