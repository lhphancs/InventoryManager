using Inventory.Abstraction.Dto;
using Inventory.Api.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ShelfInfoMapper
    {
        public static ShelfInfoDto MapToDto(ShelfInfo ShelfInfo)
        {
            return new ShelfInfoDto
            {
                Name = ShelfInfo.Name,
                Description = ShelfInfo.Description
            };
        }

        public static IEnumerable<ShelfInfoDto> MapToDto(IEnumerable<ShelfInfo> ShelfInfos)
        {
            var ShelfInfoDtos = ShelfInfos.Select(x => MapToDto(x));
            return ShelfInfoDtos;
        }
    }
}
