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
    public class ProductQueryGetById : IRequest<ProductDto>
    {
        private readonly int Id;
        public ProductQueryGetById(int id)
        {
            Id = id;
        }

        public class ProductGetByUpcQueryHandler : IRequestHandler<ProductQueryGetById, ProductDto>
        {
            private readonly InventoryContext _context;

            public ProductGetByUpcQueryHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<ProductDto> Handle(ProductQueryGetById request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (product == null)
                {
                    throw new KeyNotFoundException($"Product Id {request.Id} not found.");
                }

                var productDto = ProductMapper.MapToDto(product);
                return productDto;
            }
        }
    }
}
