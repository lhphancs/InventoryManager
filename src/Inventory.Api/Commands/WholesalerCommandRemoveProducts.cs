using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates;
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
    public class WholesalerCommandRemoveProducts : IRequest<WholesalerDto>
    {
        private readonly int WholesalerId;
        private readonly List<string> Upcs;

        public WholesalerCommandRemoveProducts(int wholesalerId, List<string> upcs)
        {
            WholesalerId = wholesalerId;
            Upcs = upcs;
        }

        public class WholesalerCommandRemoveProductHandler : IRequestHandler<WholesalerCommandRemoveProducts, WholesalerDto>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandRemoveProductHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<WholesalerDto> Handle(WholesalerCommandRemoveProducts request, CancellationToken cancellationToken)
            {
                var wholesaler = _context.Wholesalers.FirstOrDefault(x => x.Id == request.WholesalerId);

                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.WholesalerId}' not found");
                }

                var productDict = await _context.Products.ToDictionaryAsync(x => x.ProductInfo.Upc, x => x);

                foreach (var upc in request.Upcs)
                {
                    if (productDict.TryGetValue(upc, out Product product))
                    {
                        wholesaler.RemoveProduct(product);
                    }
                    else
                    {
                        throw new InvalidOperationException($"ProductUpc '{upc}' not found");
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return WholesalerMapper.MapToDto(wholesaler);
            }
        }
    }
}
