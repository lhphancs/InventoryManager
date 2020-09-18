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
        private readonly List<int> ShelfLocationIds;

        public ShelfCommandDeleteShelfProducts(int shelfId, List<int> shelfLocationIds)
        {
            ShelfId = shelfId;
            ShelfLocationIds = shelfLocationIds;
        }

        public class ShelfCommandDeleteShelfLocationsHandler : IRequestHandler<ShelfCommandDeleteShelfProducts, ShelfDto>
        {
            private readonly InventoryContext _context;

            public ShelfCommandDeleteShelfLocationsHandler(InventoryContext context)
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

                var shelfLocationDict = shelf.ShelfProducts.ToDictionary(x => x.Id, x => x);

                foreach (var shelfLocationId in request.ShelfLocationIds)
                {
                    if (shelfLocationDict.TryGetValue(shelfLocationId, out ShelfProduct shelfLocation))
                    {
                        shelf.DeleteShelfLocation(shelfLocation);
                    }
                    else
                    {
                        throw new InvalidOperationException($"ShelfLocationId '{shelfLocationId}' not found");
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);

                return ShelfMapper.MapToDto(shelf);
            }
        }
    }
}
