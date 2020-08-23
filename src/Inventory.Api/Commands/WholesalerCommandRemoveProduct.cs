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
    public class WholesalerCommandRemoveProduct : IRequest<WholesalerDto>
    {
        private readonly int WholesalerId;
        private readonly int ProductId;

        public WholesalerCommandRemoveProduct(int wholesalerId, int productId)
        {
            WholesalerId = wholesalerId;
            ProductId = productId;
        }

        public class WholesalerCommandRemoveProductHandler : IRequestHandler<WholesalerCommandRemoveProduct, WholesalerDto>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandRemoveProductHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<WholesalerDto> Handle(WholesalerCommandRemoveProduct request, CancellationToken cancellationToken)
            {
                var wholesaler = _context.Wholesalers.FirstOrDefault(x => x.Id == request.WholesalerId);

                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.WholesalerId}' not found");
                }

                var product = _context.Products.FirstOrDefault(x => x.Id == request.ProductId);

                if (product == null)
                {
                    throw new InvalidOperationException($"ProductId '{request.ProductId}' not found");
                }

                wholesaler.RemoveProduct(product);

                await _context.SaveChangesAsync(cancellationToken);

                return WholesalerMapper.MapToDto(wholesaler);
            }
        }
    }
}
