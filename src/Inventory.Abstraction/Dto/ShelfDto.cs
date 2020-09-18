using System;
using System.Collections.Generic;

namespace Inventory.Abstraction.Dto
{
    public class ShelfDto
    {
        public int Id { get; set; }
        public ShelfInfoDto ShelfInfo { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public IEnumerable<ShelfProductDto> ShelfLocations { get; set; }
    }
}