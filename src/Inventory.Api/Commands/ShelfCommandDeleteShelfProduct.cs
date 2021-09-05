using Inventory.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class ShelfCommandDeleteShelfProduct : IRequest<Unit>
    {
        private readonly int ShelfId;
        private readonly int ShelfProductId;

        public ShelfCommandDeleteShelfProduct(int shelfId, int shelfProductId)
        {
            ShelfId = shelfId;
            ShelfProductId = shelfProductId;
        }

        public class ShelfCommandDeleteShelfProductHandler : IRequestHandler<ShelfCommandDeleteShelfProduct, Unit>
        {
            private readonly InventoryContext _context;

            public ShelfCommandDeleteShelfProductHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ShelfCommandDeleteShelfProduct request, CancellationToken cancellationToken)
            {
                var shelf = await _context.Shelfs.Include(x => x.ShelfProducts).FirstOrDefaultAsync(x => x.Id == request.ShelfId);

                if (shelf == null)
                {
                    throw new InvalidOperationException($"ShelfId '{request.ShelfId}' not found");
                }
                shelf.DeleteShelfProduct(request.ShelfProductId);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
