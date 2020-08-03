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
        private readonly string UpcOfProdctToUpdate;
        private readonly ProductQuantityChangeInfo ProductQuantityChangeInfo;


        public ProductCommandReceive(string upcOfProdctToUpdate, ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            UpcOfProdctToUpdate = upcOfProdctToUpdate;
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
                var product = _context.Products.FirstOrDefault(x => x.Upc == request.UpcOfProdctToUpdate);
                if (product == null)
                {
                    throw new InvalidOperationException($"Upc '{request.UpcOfProdctToUpdate}' not found");
                }
                product.RecieveIn(request.ProductQuantityChangeInfo);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
