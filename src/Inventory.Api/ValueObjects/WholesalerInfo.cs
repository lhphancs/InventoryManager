using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using System.Collections.Generic;

namespace Inventory.Api.ValueObjects
{
    public class WholesalerInfo : ValueObject
    {
        public WholesalerInfo() { }

        public WholesalerInfo(WholesalerInfoDto wholesalerInfoDto)
        {
            Name = wholesalerInfoDto.Name;
            Address = new Address(wholesalerInfoDto.Address.Street,
                                    wholesalerInfoDto.Address.City,
                                    wholesalerInfoDto.Address.ZipCode);
        }

        public string Name { get; private set; }
        public Address Address { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
        }
    }
}
