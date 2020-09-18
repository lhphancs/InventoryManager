using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Inventory.Api.Commands
{
    public class ShelfCommandAddShelfProduct : IRequest
    {
        private readonly int ProductId;
        private readonly int ShelfId;
        private readonly int Row;
        private readonly int Position;

        public ShelfCommandAddShelfProduct(int productId, int shelfId, int row, int position)
        {
            ProductId = productId;
            ShelfId = shelfId;
            Row = row;
            Position = position;
        }

        public class ShelfCommandAddShelfProductHandler : IRequestHandler<ShelfCommandAddShelfProduct>
        {
            private readonly InventoryContext _context;

            public ShelfCommandAddShelfProductHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ShelfCommandAddShelfProduct request, CancellationToken cancellationToken)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id == request.ProductId);
                if (product == null)
                {
                    throw new InvalidOperationException($"Product '{request.ProductId}' not found");
                }

                var shelf = _context.Shelfs.FirstOrDefault(x => x.Id == request.ShelfId);
                if (shelf == null)
                {
                    throw new InvalidOperationException($"Shelf '{request.ShelfId}' not found");
                }
                shelf.AddShelfProduct(request.ProductId, request.Row, request.Position);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
