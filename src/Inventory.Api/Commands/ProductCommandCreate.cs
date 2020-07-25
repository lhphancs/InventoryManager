using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Aggregates;
using Inventory.Abstraction.Dto;

namespace Inventory.Api.Commands
{
    public class ProductCommandCreate : IRequest
    {
        private readonly ProductDto ProductDto;
        public ProductCommandCreate(ProductDto productDto)
        {
            ProductDto = productDto;
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
                var product = new Product(request.ProductDto);
                _context.Products.Add(product);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
