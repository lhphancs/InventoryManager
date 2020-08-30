using System.Collections.Generic;
using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;
using System;
using System.Linq;

namespace Inventory.Api.Queries
{
    public class ProductQueryGetAllNotInWholesaler : IRequest<IEnumerable<ProductDto>>
    {
        private readonly int WholesalerId;
        public ProductQueryGetAllNotInWholesaler(int wholesalerId)
        {
            WholesalerId = wholesalerId;
        }

        public class ProductQueryGetAllNotInWholesalerHandler : IRequestHandler<ProductQueryGetAllNotInWholesaler, IEnumerable<ProductDto>>
        {
            private readonly InventoryContext _context;

            public ProductQueryGetAllNotInWholesalerHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ProductDto>> Handle(ProductQueryGetAllNotInWholesaler request, CancellationToken cancellationToken)
            {
                var wholesaler = await _context.Wholesalers
                                        .Include(x => x.Products)
                                        .FirstOrDefaultAsync(x => x.Id == request.WholesalerId);
                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.WholesalerId}' not found");
                }
                var wholesalerProductIds = wholesaler.Products.Select(x => x.Id).ToHashSet();

                var products = await _context.Products.Where(x => !wholesalerProductIds.Contains(x.Id)).ToListAsync();
                var productDtos = ProductMapper.MapToDto(products);
                return productDtos;
            }
        }
    }
}
