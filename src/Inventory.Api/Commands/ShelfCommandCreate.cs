﻿using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;

namespace Inventory.Api.Commands
{
    public class ShelfCommandCreate : IRequest
    {
        private readonly ShelfDto ShelfDto;
        public ShelfCommandCreate(ShelfDto shelfDto)
        {
            ShelfDto = shelfDto;
        }

        public class ProductCommandCreateHandler : IRequestHandler<ShelfCommandCreate>
        {
            private readonly InventoryContext _context;

            public ProductCommandCreateHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(ShelfCommandCreate request, CancellationToken cancellationToken)
            {
                var shelf = new Shelf(request.ShelfDto);
                _context.Shelfs.Add(shelf);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}