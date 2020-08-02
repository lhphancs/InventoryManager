using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Inventory.Abstraction.Dto;

namespace Inventory.Api.Commands
{
    public class ProductCommandUpdate : IRequest
    {
        private readonly string UpcOfProdctToUpdate;
        private readonly ProductDto ProductDto;
        public ProductCommandUpdate(string upcOfProdctToUpdate, ProductDto productDto)
        {
            UpcOfProdctToUpdate = upcOfProdctToUpdate;
            ProductDto = productDto;
        }

        public class ProductCommandUpdateHandler : IRequestHandler<ProductCommandUpdate>
        {
            private readonly InventoryContext _context;

            public ProductCommandUpdateHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ProductCommandUpdate request, CancellationToken cancellationToken)
            {
                var product = _context.Products.FirstOrDefault(x => x.Upc == request.UpcOfProdctToUpdate);
                if (product == null)
                {
                    throw new InvalidOperationException($"Upc '{request.UpcOfProdctToUpdate}' not found");
                }
                product.UpdateProductInfo(request.ProductDto.ProductInfoDto);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
