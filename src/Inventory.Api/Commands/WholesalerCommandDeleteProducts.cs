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
    public class WholesalerCommandDeleteProducts : IRequest<WholesalerDto>
    {
        private readonly int WholesalerId;
        private readonly List<string> Upcs;

        public WholesalerCommandDeleteProducts(int wholesalerId, List<string> upcs)
        {
            WholesalerId = wholesalerId;
            Upcs = upcs;
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
                var wholesaler = await _context.Wholesalers.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == request.WholesalerId);

                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.WholesalerId}' not found");
                }

                var productDict = wholesaler.Products.ToDictionary(x => x.ProductInfo.Upc, x => x);

                foreach (var upc in request.Upcs)
                {
                    if (productDict.TryGetValue(upc, out Product product))
                    {
                        wholesaler.DeleteProduct(product);
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
