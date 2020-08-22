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
        private readonly ProductInfoDto ProductInfoDto;
        public ProductCommandCreate(ProductInfoDto productInfoDto)
        {
            ProductInfoDto = productInfoDto;
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
                var existingProductWithUpc = _context.Products.FirstOrDefault(x => x.ProductInfo.Upc == request.ProductInfoDto.Upc);
                if (existingProductWithUpc != null)
                {
                    throw new InvalidOperationException($"Duplicate UPC: '{request.ProductInfoDto.Upc}'");
                }

                var product = new Product(request.ProductInfoDto);
                _context.Products.Add(product);

                await _context.SaveChangesAsync(cancellationToken);

                return ProductMapper.MapToDto(product);
            }
        }
    }
}
