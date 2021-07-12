using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class WholesalerCommandDeleteProducts : IRequest<WholesalerDto>
    {
        private readonly int WholesalerId;
        private readonly List<int> ProductIds;

        public WholesalerCommandDeleteProducts(int wholesalerId, List<int> productIds)
        {
            WholesalerId = wholesalerId;
            ProductIds = productIds;
        }

        public class WholesalerCommandRemoveProductHandler : IRequestHandler<WholesalerCommandDeleteProducts, WholesalerDto>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandRemoveProductHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<WholesalerDto> Handle(WholesalerCommandDeleteProducts request, CancellationToken cancellationToken)
            {
                var wholesaler = await _context.Wholesalers.Include(x => x.ProductWholesalers).FirstOrDefaultAsync(x => x.Id == request.WholesalerId);

                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.WholesalerId}' not found");
                }

                foreach (var productId in request.ProductIds)
                {
                    var productWholesaler = wholesaler.ProductWholesalers.FirstOrDefault(x => x.ProductId == productId);
                    if (productWholesaler == null)
                    {
                        throw new InvalidOperationException($"ProductId '{productId}' not found in wholesalerId '{request.WholesalerId}'");
                    }
                    wholesaler.DeleteProduct(productId);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return WholesalerMapper.MapToDto(wholesaler);
            }
        }
    }
}
