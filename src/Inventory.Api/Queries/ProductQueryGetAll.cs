using System.Collections.Generic;
using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Api.Aggregates;

namespace Inventory.Api.Queries
{
    public class ProductQueryGetAll : IRequest<List<Product>>
    {
        public ProductQueryGetAll()
        {

        }

        public class ProductGetAllQueryHandler : IRequestHandler<ProductQueryGetAll, List<Product>>
        {
            private readonly InventoryContext _context;

            public ProductGetAllQueryHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<List<Product>> Handle(ProductQueryGetAll request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync();
                return products;
            }
        }
    }
}
