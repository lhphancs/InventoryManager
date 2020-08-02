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
                ProductInfoDto = ProductInfoMapper.MapProductInfoToProductInfoDto(product.ProductInfo),
                ProductPreparationInfoDtorationInfo = ProductPreparationInfoMapper.MapProductPreparationInfoToProductPreparationInfoDto(product.ProductPreparationInfo),

               
                Quantity = product.Quantity,
                ShelfLocationId = product.ShelfLocationId,
                ShelfLocation = ShelfLocationMapper.MapShelfLocationToShelfLocationDto(product.ShelfLocation)
            };
        }

        public static IEnumerable<ProductDto> MapProductToProductDto(IEnumerable<Product> products)
        {
            var productDtos = products.Select(x => MapProductToProductDto(x));
            return productDtos;
        }
    }
}
