using Inventory.Api.Aggregates.Shelf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Api.Infrastructure.EntityConfigurations
{
    class ShelfLocationEntityConfiguration : IEntityTypeConfiguration<ShelfLocation>
    {
        public void Configure(EntityTypeBuilder<ShelfLocation> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
