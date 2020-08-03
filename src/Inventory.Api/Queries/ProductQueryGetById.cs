using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;

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
                var productDto = ProductMapper.MapProductToProductDto(product);
                return productDto;
            }
        }
    }
}
