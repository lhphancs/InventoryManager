using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates;

namespace Inventory.Api.Commands
{
    public class ProductCommandCreate : IRequest
    {
        private readonly ProductInformation model;
        public ProductCommandCreate(ProductInformation mod)
        {
            model = mod;
        }

        public class ProductCommandCreateHandler : IRequestHandler<ProductCommandCreate>
        {
            private readonly InventoryContext _context;

            public ProductCommandCreateHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ProductCommandCreate request, CancellationToken cancellationToken)
            {
                var product = new Product(request.model);
                _context.Products.Add(product);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
