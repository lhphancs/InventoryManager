using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;

namespace Inventory.Api.Queries
{
    public class ProductQueryGetByUpc : IRequest<ProductDto>
    {
        private readonly string Upc;
        public ProductQueryGetByUpc(string upc)
        {
            Upc = upc;
        }

        public class ProductGetByUpcQueryHandler : IRequestHandler<ProductQueryGetByUpc, ProductDto>
        {
            private readonly InventoryContext _context;

            public ProductGetByUpcQueryHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<ProductDto> Handle(ProductQueryGetByUpc request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Upc == request.Upc);
                var productDto = ProductMapper.MapProductToProductDto(product);
                return productDto;
            }
        }
    }
}
