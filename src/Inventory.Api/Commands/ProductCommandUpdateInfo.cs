using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class ProductCommandUpdateInfo : IRequest<ProductDto>
    {
        private readonly int Id;
        private readonly ProductInfoDto ProductInfoDto;
        public ProductCommandUpdateInfo(int id, ProductInfoDto productInfoDto)
        {
            Id = id;
            ProductInfoDto = productInfoDto;
        }

        public class ProductCommandUpdateInfoHandler : IRequestHandler<ProductCommandUpdateInfo, ProductDto>
        {
            private readonly InventoryContext _context;

            public ProductCommandUpdateInfoHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<ProductDto> Handle(ProductCommandUpdateInfo request, CancellationToken cancellationToken)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == request.Id);
                if (product == null)
                {
                    throw new InvalidOperationException($"ProductId '{request.Id}' not found");
                }
                product.UpdateProductInfo(request.ProductInfoDto);
                await _context.SaveChangesAsync(cancellationToken);

                return ProductMapper.MapToDto(product);
            }
        }
    }
}
