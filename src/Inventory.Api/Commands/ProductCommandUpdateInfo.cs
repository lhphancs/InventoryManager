using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Inventory.Abstraction.Dto;

namespace Inventory.Api.Commands
{
    public class ProductCommandUpdateInfo : IRequest
    {
        private readonly string UpcOfProdctToUpdate;
        private readonly ProductInfoDto ProductInfoDto;
        public ProductCommandUpdateInfo(string upcOfProdctToUpdate, ProductInfoDto productInfoDto)
        {
            UpcOfProdctToUpdate = upcOfProdctToUpdate;
            ProductInfoDto = productInfoDto;
        }

        public class ProductCommandUpdateInfoHandler : IRequestHandler<ProductCommandUpdateInfo>
        {
            private readonly InventoryContext _context;

            public ProductCommandUpdateInfoHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ProductCommandUpdateInfo request, CancellationToken cancellationToken)
            {
                var product = _context.Products.FirstOrDefault(x => x.Upc == request.UpcOfProdctToUpdate);
                if (product == null)
                {
                    throw new InvalidOperationException($"Upc '{request.UpcOfProdctToUpdate}' not found");
                }
                product.UpdateProductInfo(request.ProductInfoDto);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
