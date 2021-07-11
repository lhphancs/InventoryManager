using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Inventory.Abstraction.Dto.Requests;

namespace Inventory.Api.Commands
{
    public class ShelfCommandCreateShelfProduct : IRequest
    {
        private readonly int ShelfId;
        private readonly int ProductId;
        private readonly int Row;
        private readonly int Column;

        public ShelfCommandCreateShelfProduct(int shelfId, ShelfProductRequestDto shelfProductRequest)
        {
            ShelfId = shelfId;
            ProductId = shelfProductRequest.ProductId;
            Row = shelfProductRequest.Row;
            Column = shelfProductRequest.Column;
        }

        public class ShelfCommandSetShelfProductsHandler : IRequestHandler<ShelfCommandCreateShelfProduct>
        {
            private readonly InventoryContext _context;

            public ShelfCommandSetShelfProductsHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ShelfCommandCreateShelfProduct request, CancellationToken cancellationToken)
            {
                var existingProductIds = _context.Products.Select(x => x.Id).ToHashSet();
                var productsNotExisting = request.ProductIds.Where(x => !existingProductIds.Contains(x));
                if (productsNotExisting.Any())
                {
                    var productIdsNotExisting = productsNotExisting.Select(x => x.ToString());
                    var prodIdsJoined = string.Join(",", productIdsNotExisting);
                    throw new InvalidOperationException($"Product not found {prodIdsJoined}");
                }

                var shelf = _context.Shelfs.FirstOrDefault(x => x.Id == request.ShelfId);
                if (shelf == null)
                {
                    throw new InvalidOperationException($"Shelf '{request.ShelfId}' not found");
                }
                shelf.SetShelfProducts(request.ProductIds, request.Row, request.Column);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
