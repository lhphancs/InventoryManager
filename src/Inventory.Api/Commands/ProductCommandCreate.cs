using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Api.Aggregates;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;
using System.Linq;
using System;

namespace Inventory.Api.Commands
{
    public class ProductCommandCreate : IRequest<ProductDto>
    {
        private readonly ProductDto ProductDto;
        public ProductCommandCreate(ProductDto productDto)
        {
            ProductDto = productDto;
        }

        public class ProductCommandCreateHandler : IRequestHandler<ProductCommandCreate, ProductDto>
        {
            private readonly InventoryContext _context;

            public ProductCommandCreateHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<ProductDto> Handle(ProductCommandCreate request, CancellationToken cancellationToken)
            {
                var existingProductWithUpc = _context.Products.FirstOrDefault(x => x.ProductInfo.Upc == request.ProductDto.ProductInfo.Upc);
                if (existingProductWithUpc != null)
                {
                    throw new InvalidOperationException($"Duplicate UPC: '{request.ProductDto.ProductInfo.Upc}'");
                }

                var product = new Product(request.ProductDto);
                _context.Products.Add(product);

                await _context.SaveChangesAsync(cancellationToken);

                return ProductMapper.MapToDto(product);
            }
        }
    }
}
