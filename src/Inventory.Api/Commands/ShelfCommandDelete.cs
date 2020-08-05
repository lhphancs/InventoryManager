using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Inventory.Api.Commands
{
    public class ShelfCommandDelete : IRequest
    {
        private readonly int Id;
        public ShelfCommandDelete(int shelfId)
        {
            Id = shelfId;
        }

        public class ShelfCommandDeleteHandler : IRequestHandler<ShelfCommandDelete>
        {
            private readonly InventoryContext _context;

            public ShelfCommandDeleteHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ShelfCommandDelete request, CancellationToken cancellationToken)
            {
                var shelf = _context.Shelfs.FirstOrDefault(x => x.Id == request.Id);
                if (shelf == null)
                {
                    throw new InvalidOperationException($"ShelfId '{request.Id}' not found");
                }
                _context.Shelfs.Remove(shelf);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
