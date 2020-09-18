using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;
using System;

namespace Inventory.Api.Queries
{
    public class ShelfQueryGetById : IRequest<ShelfDto>
    {
        private readonly int Id;
        public ShelfQueryGetById(int id)
        {
            Id = id;
        }

        public class ShelfGetByUpcQueryHandler : IRequestHandler<ShelfQueryGetById, ShelfDto>
        {
            private readonly InventoryContext _context;

            public ShelfGetByUpcQueryHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<ShelfDto> Handle(ShelfQueryGetById request, CancellationToken cancellationToken)
            {
                var shelf = await _context.Shelfs.Include(x => x.ShelfProducts).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (shelf == null)
                {
                    throw new InvalidOperationException($"ShelfId '{request.Id}' not found");
                }

                var shelfDto = ShelfMapper.MapToDto(shelf);
                return shelfDto;
            }
        }
    }
}
