using Inventory.Api.Aggregates;
using Inventory.Api.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Infrastructure
{
    public class InventoryContext : DbContext, IInventoryContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new ShelfEntityConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySQL("DataSource=app.db");
    }

    
}
