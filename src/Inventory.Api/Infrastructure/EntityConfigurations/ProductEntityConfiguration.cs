using Inventory.Api.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Api.Infrastructure.EntityConfigurations
{
    class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.ShelfProduct).WithOne().HasForeignKey<Product>(x => x.ShelfProductId);
            builder.OwnsOne(x => x.ProductInfo, x =>
            {
                x.HasIndex(x => x.Upc).IsUnique();
            });
        }
    }
}
