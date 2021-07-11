namespace Inventory.Abstraction.Dto.Requests
{
    public class ShelfProductRequestDto
    {
        public int ProductId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
