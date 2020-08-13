using System.Collections.Generic;
using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;

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
                var shelfs = await _context.Shelfs.ToListAsync();
                var shelfDtos = ShelfMapper.MapToDto(shelfs);
                return shelfDtos;
            }
        }
    }
}
