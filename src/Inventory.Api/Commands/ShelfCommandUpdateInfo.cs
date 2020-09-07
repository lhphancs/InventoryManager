using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;

namespace Inventory.Api.Commands
{
    public class ShelfCommandUpdateInfo : IRequest<ShelfDto>
    {
        private readonly int Id;
        private readonly ShelfInfoDto ShelfInfoDto;
        public ShelfCommandUpdateInfo(int id, ShelfInfoDto shelfInfoDto)
        {
            Id = id;
            ShelfInfoDto = shelfInfoDto;
        }

        public class ShelfCommandUpdateAddressHandler : IRequestHandler<ShelfCommandUpdateInfo, ShelfDto>
        {
            private readonly InventoryContext _context;

            public ShelfCommandUpdateAddressHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<ShelfDto> Handle(ShelfCommandUpdateInfo request, CancellationToken cancellationToken)
            {
                var shelf = _context.Shelfs.FirstOrDefault(x => x.Id == request.Id);
                if (shelf == null)
                {
                    throw new InvalidOperationException($"ShelfId '{request.Id}' not found");
                }
                shelf.UpdateShelfInfo(request.ShelfInfoDto);
                await _context.SaveChangesAsync(cancellationToken);

                return ShelfMapper.MapToDto(shelf);
            }
        }
    }
}
