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
    public class WholesalerCommandAddProducts : IRequest<WholesalerDto>
    {
        private readonly int WholesalerId;
        private readonly List<int> ProductIds;

        public WholesalerCommandAddProducts(int wholesalerId, List<int> productIds)
        {
            WholesalerId = wholesalerId;
            ProductIds = productIds;
        }

        public class WholesalerCommandAddProductsHandler : IRequestHandler<WholesalerCommandAddProducts, WholesalerDto>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandAddProductsHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<WholesalerDto> Handle(WholesalerCommandAddProducts request, CancellationToken cancellationToken)
            {
                var wholesaler = _context
                                    .Wholesalers
                                    .Include(x => x.ProductWholesalers)
                                    .FirstOrDefault(x => x.Id == request.WholesalerId);

                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.WholesalerId}' not found");
                }

                var productIds = await _context.Products.Select(x => x.Id).ToListAsync();
                var productIdSet = productIds.ToHashSet();

                foreach (var productId in request.ProductIds)
                {
                    if (!productIdSet.Contains(productId))
                    {
                        throw new InvalidOperationException($"ProductId '{productId}' not found");
                    }
                    wholesaler.AddProduct(productId);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return WholesalerMapper.MapToDto(wholesaler);
            }
        }
    }
}
