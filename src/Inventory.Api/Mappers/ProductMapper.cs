using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                ProductInfo = ProductInfoMapper.MapToDto(product.ProductInfo),

               
                Quantity = product.Quantity,
                ShelfProductId = product.ShelfProductId,
                ShelfProduct = product.ShelfProduct == null ? null : ShelfProductMapper.MapToDto(product.ShelfProduct),

                CreatedDateTime = product.CreatedDateTime,
                ModifiedDateTime = product.ModifiedDateTime
            };
        }

        public static IEnumerable<ProductDto> MapToDto(IEnumerable<Product> products)
        {
            var productDtos = products.Select(x => MapToDto(x));
            return productDtos;
        }
    }
}
