using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Queries
{
    public class ProductQueryGetAll : IRequest<IEnumerable<ProductDto>>
    {
        public ProductQueryGetAll()
        {

        }

        public class ProductGetAllQueryHandler : IRequestHandler<ProductQueryGetAll, IEnumerable<ProductDto>>
        {
            private readonly InventoryContext _context;

            public ProductGetAllQueryHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ProductDto>> Handle(ProductQueryGetAll request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync();
                var productDtos = ProductMapper.MapToDto(products);
                return productDtos;
            }
        }
    }
}
