using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Inventory.Api.Commands
{
    public class ShelfCommandAddShelfLocation : IRequest
    {
        private readonly int ShelfId;
        private readonly int Row;
        private readonly int Position;

        public ShelfCommandAddShelfLocation(int shelfId, int row, int position)
        {
            ShelfId = shelfId;
            Row = row;
            Position = position;
        }

        public class ShelfCommandAddShelfLocationHandler : IRequestHandler<ShelfCommandAddShelfLocation>
        {
            private readonly InventoryContext _context;

            public ShelfCommandAddShelfLocationHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ShelfCommandAddShelfLocation request, CancellationToken cancellationToken)
            {
                var shelf = _context.Shelfs.FirstOrDefault(x => x.Id == request.ShelfId);
                if (shelf == null)
                {
                    throw new InvalidOperationException($"Shelf '{request.ShelfId}' not found");
                }
                shelf.AddShelfLocation(request.Row, request.Position);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
