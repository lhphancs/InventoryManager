using Inventory.Api.Infrastructure.EntityConfigurations.ManyToManyClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Api.Infrastructure.EntityConfigurations
{
    class ProductWholesalerEntityConfiguration : IEntityTypeConfiguration<ProductWholesaler>
    {
        public void Configure(EntityTypeBuilder<ProductWholesaler> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.WholesalerId });
            builder.HasOne(x => x.Product).WithMany(x => x.ProductWholesalers).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Wholesaler).WithMany(x => x.ProductWholesalers).HasForeignKey(x => x.WholesalerId);
        }
    }
}
