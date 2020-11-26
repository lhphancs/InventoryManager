using System.Collections.Generic;

namespace Inventory.Abstraction.Dto.Requests
{
    public class RequestModelSetShelfProducts
    {
        public List<int> ProductIds { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
