using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto MapProductToProductDto(Product product)
        {
            return new ProductDto
            {
                Upc = product.Upc,
                Brand = product.Brand,
                Name = product.Name,
                Description = product.Description,
                ExpirationLocation = product.ExpirationLocation,
                ImageUrl = product.ImageUrl,
                OunceWeight = product.OunceWeight,
                RequiresPadding = product.RequiresPadding,
                RequiresBubbleWrap = product.RequiresBubbleWrap,
                Quantity = product.Quantity,
                ShelfLocationId = product.ShelfLocationId,
                ShelfLocation = ShelfLocationMapper.MapShelfLocationToShelfLocationDto(product.ShelfLocation)
            };
        }

        public static IEnumerable<ProductDto> MapProductToProductDto(IEnumerable<Product> products)
        {
            var productDtos = products.Select(x => new ProductDto
            {
                Upc = x.Upc,
                Brand = x.Brand,
                Name = x.Name,
                Description = x.Description,
                ExpirationLocation = x.ExpirationLocation,
                ImageUrl = x.ImageUrl,
                OunceWeight = x.OunceWeight,
                RequiresPadding = x.RequiresPadding,
                RequiresBubbleWrap = x.RequiresBubbleWrap,
                Quantity = x.Quantity,
                ShelfLocationId = x.ShelfLocationId,
                ShelfLocation = ShelfLocationMapper.MapShelfLocationToShelfLocationDto(x.ShelfLocation)
            });
            return productDtos;
        }
    }
}
