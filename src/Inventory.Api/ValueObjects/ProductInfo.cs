using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using System.Collections.Generic;

namespace Inventory.Api.ValueObjects
{
    public class ProductInfo : ValueObject
    {
        public ProductInfo() { }

        public ProductInfo(ProductInfoDto productInfoDto)
        {
            Brand = productInfoDto.Brand;
            Name = productInfoDto.Name;
            Description = productInfoDto.Description;
            ExpirationLocation = productInfoDto.ExpirationLocation;
            OunceWeight = productInfoDto.OunceWeight;
        }

        public string Brand { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ExpirationLocation { get; private set; }
        public int OunceWeight { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Brand;
            yield return Name;
            yield return Description;
            yield return ExpirationLocation;
            yield return OunceWeight;
        }
    }
}
