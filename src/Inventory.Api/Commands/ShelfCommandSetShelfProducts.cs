using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Inventory.Api.Commands
{
    public class ShelfCommandSetShelfProducts : IRequest
    {
        private readonly List<int> ProductIds;
        private readonly int ShelfId;
        private readonly int Row;
        private readonly int Column;

        public ShelfCommandSetShelfProducts(int shelfId, List<int> productIds, int row, int column)
        {
            ShelfId = shelfId;
            ProductIds = productIds;
            Row = row;
            Column = column;
        }

        public class ShelfCommandSetShelfProductsHandler : IRequestHandler<ShelfCommandSetShelfProducts>
        {
            private readonly InventoryContext _context;

            public ShelfCommandSetShelfProductsHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ShelfCommandSetShelfProducts request, CancellationToken cancellationToken)
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
