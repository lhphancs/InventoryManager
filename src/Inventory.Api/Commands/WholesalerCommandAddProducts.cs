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
    public class WholesalerCommandAddProducts : IRequest<WholesalerDto>
    {
        private readonly int WholesalerId;
        private readonly List<string> Upcs;

        public WholesalerCommandAddProducts(int wholesalerId, List<string> upcs)
        {
            WholesalerId = wholesalerId;
            Upcs = upcs;
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
                                    .Include(x => x.Products)
                                    .FirstOrDefault(x => x.Id == request.WholesalerId);

                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.WholesalerId}' not found");
                }

                var productDict = await _context.Products.ToDictionaryAsync(x => x.ProductInfo.Upc, x => x);

                foreach(var upc in request.Upcs)
                {
                    if (productDict.TryGetValue(upc, out Product product))
                    {
                        wholesaler.AddProduct(product);
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
