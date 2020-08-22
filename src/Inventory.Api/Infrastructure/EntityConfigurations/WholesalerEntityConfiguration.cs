using Inventory.Api.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Api.Infrastructure.EntityConfigurations
{
    class WholesalerEntityConfiguration : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.WholesalerInfo, x =>
            {
                x.OwnsOne(x => x.Address);
                x.HasIndex(x => x.Name).IsUnique();
            });
        }
    }
}
