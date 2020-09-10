using Inventory.Api.Aggregates.Shelf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Api.Infrastructure.EntityConfigurations
{
    class ShelfEntityConfiguration : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.ShelfLocations).WithOne().HasForeignKey(x => x.Id);

            builder.OwnsOne(x => x.ShelfInfo);
        }
    }
}
