using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Inventory.Api.ValueObjects;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;

namespace Inventory.Api.Commands
{
    public class ProductCommandReceive : IRequest<ProductDto>
    {
        private readonly ProductQuantityChangeInfo ProductQuantityChangeInfo;


        public ProductCommandReceive(ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            ProductQuantityChangeInfo = productQuantityChangeInfo;
        }

        public class ProductCommandUpdateQuantityHandler : IRequestHandler<ProductCommandReceive, ProductDto>
        {
            private readonly InventoryContext _context;

            public ProductCommandUpdateQuantityHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<ProductDto> Handle(ProductCommandReceive request, CancellationToken cancellationToken)
            {
                var upcOfProductToUpdate = request.ProductQuantityChangeInfo.Upc;
                var product = _context.Products.FirstOrDefault(x => x.ProductInfo.Upc == upcOfProductToUpdate);
                if (product == null)
                {
                    throw new InvalidOperationException($"'{upcOfProductToUpdate}' not found");
                }
                product.RecieveIn(request.ProductQuantityChangeInfo);
                await _context.SaveEntitiesAsync(cancellationToken);

                return ProductMapper.MapToDto(product);
            }
        }
    }
}
