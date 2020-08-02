using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ProductInfoMapper
    {
        public static ProductInfoDto MapProductInfoToProductInfoDto(ProductInfo productInfo)
        {
            return new ProductInfoDto
            {
                Brand = productInfo.Brand,
                Name = productInfo.Name,
                Description = productInfo.Description,
                ExpirationLocation = productInfo.ExpirationLocation,
                OunceWeight = productInfo.OunceWeight
            };
        }

        public static IEnumerable<ProductInfoDto> MapProductInfoToProductInfoDto(IEnumerable<ProductInfo> productInfos)
        {
            var productInfoDtos = productInfos.Select(x => MapProductInfoToProductInfoDto(x));
            return productInfoDtos;
        }
    }
}
