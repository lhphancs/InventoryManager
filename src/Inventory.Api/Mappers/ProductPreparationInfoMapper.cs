using Inventory.Abstraction.Dto;
using Inventory.Api.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ProductPreparationInfoMapper
    {
        public static ProductPreparationInfoDto MapToDto(ProductPreparationInfo productPreparationInfo)
        {
            return new ProductPreparationInfoDto
            {
                RequiresPadding = productPreparationInfo.RequiresPadding,
                RequiresBubbleWrap = productPreparationInfo.RequiresBubbleWrap,
                RequiresBox = productPreparationInfo.RequiresBox
            };
        }

        public static IEnumerable<ProductPreparationInfoDto> MapToDto(IEnumerable<ProductPreparationInfo> productPreparationInfos)
        {
            var productPreparationInfoDtos = productPreparationInfos.Select(x => MapToDto(x));
            return productPreparationInfoDtos;
        }
    }
}
