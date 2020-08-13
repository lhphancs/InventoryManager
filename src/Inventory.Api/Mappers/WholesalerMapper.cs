using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class WholesalerMapper
    {
        public static WholesalerDto MapToDto(Wholesaler wholesaler)
        {
            return new WholesalerDto
            {
                Id = wholesaler.Id,
                Address = new AddressDto
                {
                    City = wholesaler.Address.City,
                    Street = wholesaler.Address.Street,
                    ZipCode = wholesaler.Address.ZipCode
                },
                Products = ProductMapper.MapToDto(wholesaler.Products),
                CreatedDateTime = wholesaler.CreatedDateTime,
                ModifiedDateTime = wholesaler.ModifiedDateTime
            };
        }

        public static IEnumerable<WholesalerDto> MapToDto(IEnumerable<Wholesaler> Wholesaler)
        {
            var WholesalerDtos = Wholesaler.Select(x => MapToDto(x));
            return WholesalerDtos;
        }
    }
}
