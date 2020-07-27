using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Inventory.Api.Commands
{
    public class ProductCommandDelete : IRequest
    {
        private readonly string UpcToDelete;
        public ProductCommandDelete(string upc)
        {
            UpcToDelete = upc;
        }

        public class ProductCommandDeleteHandler : IRequestHandler<ProductCommandDelete>
        {
            private readonly InventoryContext _context;

            public ProductCommandDeleteHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ProductCommandDelete request, CancellationToken cancellationToken)
            {
                var product = _context.Products.FirstOrDefault(x => x.Upc == request.UpcToDelete);
                if (product == null)
                {
                    throw new InvalidOperationException($"Upc '{request.UpcToDelete}' not found");
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
