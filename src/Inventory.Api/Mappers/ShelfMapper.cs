using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Api.Mappers
{
    public static class ShelfMapper
    {
        public static ShelfDto MapToDto(Shelf shelf)
        {
            return new ShelfDto
            {
                Id = shelf.Id,
                Name = shelf.Name,
                Description = shelf.Description,
                ShelfLocations = ShelfLocationMapper.MapToDto(shelf.ShelfLocations),
                CreatedDateTime = shelf.CreatedDateTime,
                ModifiedDateTime = shelf.ModifiedDateTime
            };
        }

        public static IEnumerable<ShelfDto> MapToDto(IEnumerable<Shelf> shelf)
        {
            var shelfDtos = shelf.Select(x => MapToDto(x));
            return shelfDtos;
        }
    }
}
