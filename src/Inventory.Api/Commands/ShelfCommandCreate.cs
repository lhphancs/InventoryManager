using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using Inventory.Api.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class ShelfCommandCreate : IRequest
    {
        private readonly ShelfInfoDto ShelfInfoDto;
        public ShelfCommandCreate(ShelfInfoDto shelfInfoDto)
        {
            ShelfInfoDto = shelfInfoDto;
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
                var shelf = new Shelf(request.ShelfInfoDto);
                _context.Shelfs.Add(shelf);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
