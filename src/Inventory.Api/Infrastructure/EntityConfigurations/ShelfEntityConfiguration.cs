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
            builder.OwnsMany(x => x.ShelfProducts, a =>
            {
                a.WithOwner(z => z.Shelf);
                a.HasKey(z => z.Id);
                a.HasIndex(z => z.ProductId).IsUnique();
            });

            builder.OwnsOne(x => x.ShelfInfo, x =>
            {
                x.HasIndex(y => y.Name).IsUnique();
            });
        }
    }
}
