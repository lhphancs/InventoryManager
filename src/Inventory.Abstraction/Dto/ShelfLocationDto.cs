using System;

namespace Inventory.Abstraction.Dto
{
    public class ShelfLocationDto
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Position { get; set; }
    }
}
