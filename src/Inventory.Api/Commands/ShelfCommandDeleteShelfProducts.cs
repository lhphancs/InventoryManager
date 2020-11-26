using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class ShelfCommandDeleteShelfProducts : IRequest<ShelfDto>
    {
        private readonly int ShelfId;
        private readonly List<int> ShelfProductIds;

        public ShelfCommandDeleteShelfProducts(int shelfId, List<int> shelfProductIds)
        {
            ShelfId = shelfId;
            ShelfProductIds = shelfProductIds;
        }

        public class ShelfCommandDeleteShelfProductsHandler : IRequestHandler<ShelfCommandDeleteShelfProducts, ShelfDto>
        {
            private readonly InventoryContext _context;

            public ShelfCommandDeleteShelfProductsHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<ShelfDto> Handle(ShelfCommandDeleteShelfProducts request, CancellationToken cancellationToken)
            {
                var shelf = await _context.Shelfs.Include(x => x.ShelfProducts).FirstOrDefaultAsync(x => x.Id == request.ShelfId);

                if (shelf == null)
                {
                    throw new InvalidOperationException($"ShelfId '{request.ShelfId}' not found");
                }

                var shelfProductDict = shelf.ShelfProducts.ToDictionary(x => x.Id, x => x);

                foreach (var shelfProductId in request.ShelfProductIds)
                {
                    if (shelfProductDict.TryGetValue(shelfProductId, out ShelfProduct shelfProduct))
                    {
                        shelf.DeleteShelfProduct(shelfProduct);
                    }
                    else
                    {
                        throw new InvalidOperationException($"ShelfProductId '{shelfProductId}' not found");
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return ShelfMapper.MapToDto(shelf);
            }
        }
    }
}
