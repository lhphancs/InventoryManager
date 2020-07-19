using Inventory.Api.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Api.Infrastructure.EntityConfigurations
{
    class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(x => x.ProductInformation);
            builder.HasOne(x => x.ShelfLocation).WithOne().HasForeignKey<Product>(x => x.ShelfLocationId);
        }
    }
}
