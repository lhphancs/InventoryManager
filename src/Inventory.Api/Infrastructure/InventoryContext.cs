using Inventory.Api.Aggregates;
using Inventory.Api.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inventory.Api.Infrastructure
{
    public class InventoryContext : DbContext, IInventoryContext
    {
        private readonly IConfiguration _configuration;

        public InventoryContext(DbContextOptions<InventoryContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new ShelfEntityConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("Database");
            options.UseMySQL(connectionString);
        }

        public virtual DbSet<Product> Products { get; set; }
    }

    
}
