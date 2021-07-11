using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Queries
{
    public class ShelfQueryGetAll : IRequest<IEnumerable<ShelfDto>>
    {
        public ShelfQueryGetAll()
        {

        }

        public class ShelfGetAllQueryHandler : IRequestHandler<ShelfQueryGetAll, IEnumerable<ShelfDto>>
        {
            private readonly InventoryContext _context;

            public ShelfGetAllQueryHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ShelfDto>> Handle(ShelfQueryGetAll request, CancellationToken cancellationToken)
            {
                var shelfs = await _context.Shelfs.Include(x => x.ShelfProducts).ToListAsync();
                var shelfDtos = ShelfMapper.MapToDto(shelfs);
                return shelfDtos;
            }
        }
    }
}
