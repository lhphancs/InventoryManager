using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ShelfLocationMapper
    {
        public static ShelfLocationDto MapToDto(ShelfLocation shelfLocation)
        {
            if (shelfLocation == null)
            {
                return null;
            }

            return new ShelfLocationDto
            {
                Id = shelfLocation.Id,
                Row = shelfLocation.Row,
                Position = shelfLocation.Position
            };
        }
        public static IEnumerable<ShelfLocationDto> MapToDto(IEnumerable<ShelfLocation> shelfLocations)
        {
            var shelfLocationDtos = shelfLocations.Select(x => MapToDto(x));
            return shelfLocationDtos;
        }
    }
}
