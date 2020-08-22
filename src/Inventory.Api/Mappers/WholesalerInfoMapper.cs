using Inventory.Abstraction.Dto;
using Inventory.Api.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class WholesalerInfoMapper
    {
        public static WholesalerInfoDto MapToDto(WholesalerInfo wholesalerInfo)
        {
            return new WholesalerInfoDto
            {
                Name = wholesalerInfo.Name,
                Address = new AddressDto
                {
                    Street = wholesalerInfo.Address.Street,
                    City = wholesalerInfo.Address.City,
                    ZipCode = wholesalerInfo.Address.ZipCode,
                }
            };
        }

        public static IEnumerable<WholesalerInfoDto> MapToDto(IEnumerable<WholesalerInfo> WholesalerInfos)
        {
            var WholesalerInfoDtos = WholesalerInfos.Select(x => MapToDto(x));
            return WholesalerInfoDtos;
        }
    }
}
