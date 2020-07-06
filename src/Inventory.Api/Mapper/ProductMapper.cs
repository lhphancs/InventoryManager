using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mapper
{
    public class ProductMapper
    {
        public ProductModel Map(Product source)
        {
            return new ProductModel
            {
                Upc = source.Upc,
                Brand = source.Brand,
                Name = source.Name,
                Description = source.Description,
                ExpirationLocation = source.ExpirationLocation,
                ImageUrl = source.ImageUrl,
                OunceWeight = source.OunceWeight,
                RequiresPadding = source.RequiresPadding,
                RequiresBubbleWrap = source.RequiresBubbleWrap,
                ShelfLocationId = source.ShelfLocationId,
                Quantity = source.Quantity,
                ShelfLocation = new ShelfLocationMapper().Map(source.ShelfLocation)
            };
        }

        public List<ProductModel> Map(List<Product> source)
        {
            return source.Select(x => Map(x)).ToList();
        }
    }
}
