using Inventory.Api.Aggregates.Shelf;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Api.Infrastructure.EntityConfigurations
{
    class ShelfProductEntityConfiguration : IEntityTypeConfiguration<ShelfProduct>
    {
        public void Configure(EntityTypeBuilder<ShelfProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.ProductId, x.Row, x.Column }).IsUnique();
        }
    }
}
