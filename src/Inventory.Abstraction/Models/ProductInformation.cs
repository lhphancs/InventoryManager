namespace Inventory.Abstraction.Models
{
    public class ProductInformation
    {
        public string Upc { get; private set; }
        public string Brand { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ExpirationLocation { get; private set; }
        public string ImageUrl { get; private set; }
        public int OunceWeight { get; private set; }

        public bool RequiresPadding { get; private set; }
        public bool RequiresBubbleWrap { get; private set; }
    }
}
