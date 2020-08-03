using System.Collections.Generic;

namespace Inventory.Abstraction.Dto
{
    public class ShelfDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ShelfLocationDto> ShelfLocations { get; set; }
    }
}