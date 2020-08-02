using Inventory.Abstraction.Dto;

namespace Inventory.Api.Aggregates
{
    public class ProductInfo
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
    }
}
