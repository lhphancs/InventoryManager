using System;
using System.Collections.Generic;

namespace Inventory.Abstraction.Dto
{
    public class WholesalerDto
    {
        public int Id { get; set; }
        public AddressDto Address { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
    }
}
