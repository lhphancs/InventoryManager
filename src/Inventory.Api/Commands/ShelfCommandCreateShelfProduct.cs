using Inventory.Api.Infrastructure;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class ShelfCommandCreateShelfProduct : IRequest
    {
        private readonly int ShelfId;
        private readonly int ProductId;
        private readonly int Row;
        private readonly int Column;

        public ShelfCommandCreateShelfProduct(int shelfId, int productId, int row, int column)
        {
            ShelfId = shelfId;
            ProductId = productId;
            Row = row;
            Column = column;
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
                var existingProduct = _context.Products.FirstOrDefault(x => x.Id == request.ProductId);
                if (existingProduct == null)
                {
                    throw new InvalidOperationException($"Product not found {request.ProductId}");
                }

                var shelf = _context.Shelfs.FirstOrDefault(x => x.Id == request.ShelfId);
                if (shelf == null)
                {
                    throw new InvalidOperationException($"Shelf '{request.ShelfId}' not found");
                }
                shelf.AddShelfProduct(request.ProductId, request.Row, request.Column);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
