using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Inventory.Api.ValueObjects;

namespace Inventory.Api.Commands
{
    public class ProductCommandReceive : IRequest
    {
        private readonly ProductQuantityChangeInfo ProductQuantityChangeInfo;


        public ProductCommandReceive(ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            ProductQuantityChangeInfo = productQuantityChangeInfo;
        }

        public class ProductCommandUpdateQuantityHandler : IRequestHandler<ProductCommandReceive>
        {
            private readonly InventoryContext _context;

            public ProductCommandUpdateQuantityHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ProductCommandReceive request, CancellationToken cancellationToken)
            {
                var upcOfProductToUpdate = request.ProductQuantityChangeInfo.Upc;
                var product = _context.Products.FirstOrDefault(x => x.Upc == upcOfProductToUpdate);
                if (product == null)
                {
                    throw new InvalidOperationException($"'{upcOfProductToUpdate}' not found");
                }
                product.RecieveIn(request.ProductQuantityChangeInfo);
                await _context.SaveEntitiesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
