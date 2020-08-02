using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ProductPreparationInfoMapper
    {
        public static ProductPreparationInfoDto MapProductPreparationInfoToProductPreparationInfoDto(ProductPreparationInfo productPreparationInfo)
        {
            return new ProductPreparationInfoDto
            {
                RequiresPadding = productPreparationInfo.RequiresPadding,
                RequiresBubbleWrap = productPreparationInfo.RequiresBubbleWrap,
                RequiresBox = productPreparationInfo.RequiresBox
            };
        }

        public static IEnumerable<ProductPreparationInfoDto> MapProductPreparationInfoToProductPreparationInfoDto(IEnumerable<ProductPreparationInfo> productPreparationInfos)
        {
            var productPreparationInfoDtos = productPreparationInfos.Select(x => MapProductPreparationInfoToProductPreparationInfoDto(x));
            return productPreparationInfoDtos;
        }
    }
}
