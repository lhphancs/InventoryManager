using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class WholesalerCommandAddProduct : IRequest<WholesalerDto>
    {
        private readonly int WholesalerId;
        private readonly string ProductUpc;

        public WholesalerCommandAddProduct(int wholesalerId, string productUpc)
        {
            WholesalerId = wholesalerId;
            ProductUpc = productUpc;
        }

        public class WholesalerCommandAddProductHandler : IRequestHandler<WholesalerCommandAddProduct, WholesalerDto>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandAddProductHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<WholesalerDto> Handle(WholesalerCommandAddProduct request, CancellationToken cancellationToken)
            {
                var wholesaler = _context.Wholesalers.FirstOrDefault(x => x.Id == request.WholesalerId);

                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.WholesalerId}' not found");
                }

                var product = _context.Products.FirstOrDefault(x => x.ProductInfo.Upc == request.ProductUpc);

                if (product == null)
                {
                    throw new InvalidOperationException($"ProductUpc '{request.ProductUpc}' not found");
                }

                wholesaler.AddProduct(product);

                await _context.SaveChangesAsync(cancellationToken);

                return WholesalerMapper.MapToDto(wholesaler);
            }
        }
    }
}
