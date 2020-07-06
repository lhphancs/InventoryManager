using Inventory.Api.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Infrastructure
{
    public interface IInventoryContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
