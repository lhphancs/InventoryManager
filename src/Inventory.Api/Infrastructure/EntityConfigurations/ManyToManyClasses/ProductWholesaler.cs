using Inventory.Api.Aggregates;

namespace Inventory.Api.Infrastructure.EntityConfigurations.ManyToManyClasses
{
    public class ProductWholesaler
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }
    }
}
