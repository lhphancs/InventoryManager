using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;

namespace Inventory.Api.Mappers
{
    public static class ShelfLocationMapper
    {
        public static ShelfLocationDto MapShelfLocationToShelfLocationDto(ShelfLocation shelfLocation)
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
    }
}
