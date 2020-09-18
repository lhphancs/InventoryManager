using Inventory.Api.Aggregates.Shelf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Api.Infrastructure.EntityConfigurations
{
    class ShelfLocationEntityConfiguration : IEntityTypeConfiguration<ShelfProduct>
    {
        public void Configure(EntityTypeBuilder<ShelfProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Id, x.Row, x.Position }).IsUnique();
        }
    }
}
