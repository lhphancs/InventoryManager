using System.Collections.Generic;

namespace Inventory.Abstraction.Dto.Requests
{
    public class RequestModelSetShelfProducts
    {
        public List<int> productIds { get; set; }
        public int row { get; set; }
        public int column { get; set; }
    }
}
