using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using System.Collections.Generic;

namespace Inventory.Api.ValueObjects
{
    public class ProductPreparationInfo : ValueObject
    {
        public ProductPreparationInfo() { }

        public ProductPreparationInfo(ProductPreparationInfoDto productPreparationInfoDto)
        {
            RequiresBubbleWrap = productPreparationInfoDto.RequiresBubbleWrap;
            RequiresPadding = productPreparationInfoDto.RequiresPadding;
            RequiresBox = productPreparationInfoDto.RequiresBox;
        }

        public bool RequiresBubbleWrap { get; private set; }
        public bool RequiresPadding { get; private set; }
        public bool RequiresBox { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RequiresBubbleWrap;
            yield return RequiresPadding;
            yield return RequiresBox;
        }
    }
}
