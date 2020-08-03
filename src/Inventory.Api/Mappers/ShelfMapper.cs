using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ShelfMapper
    {
        public static ShelfDto MapShelfToShelfDto(Shelf shelf)
        {
            return new ShelfDto
            {
                Id = shelf.Id,
                Name = shelf.Name,
                Description = shelf.Description,
                ShelfLocations = ShelfLocationMapper.MapShelfLocationToShelfLocationDto(shelf.ShelfLocations)
            };
        }

        public static IEnumerable<ShelfDto> MapShelfToShelfDto(IEnumerable<Shelf> shelf)
        {
            var shelfDtos = shelf.Select(x => MapShelfToShelfDto(x));
            return shelfDtos;
        }
    }
}
