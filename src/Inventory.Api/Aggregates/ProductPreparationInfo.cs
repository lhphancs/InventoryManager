using Inventory.Abstraction.Dto;

namespace Inventory.Api.Aggregates
{
    public class ProductPreparationInfo
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
    }
}
