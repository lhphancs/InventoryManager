using System;

namespace Inventory.Abstraction.Dto
{
    public class ShelfLocationDto
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Position { get; set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }
    }
}
