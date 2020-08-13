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
    public class WholesalerQueryGetAll : IRequest<IEnumerable<WholesalerDto>>
    {
        public WholesalerQueryGetAll()
        {

        }

        public class WholesalerGetAllQueryHandler : IRequestHandler<WholesalerQueryGetAll, IEnumerable<WholesalerDto>>
        {
            private readonly InventoryContext _context;

            public WholesalerGetAllQueryHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<WholesalerDto>> Handle(WholesalerQueryGetAll request, CancellationToken cancellationToken)
            {
                var wholesalers = await _context.Wholesalers.ToListAsync();
                var WholesalerDtos = WholesalerMapper.MapToDto(wholesalers);
                return WholesalerDtos;
            }
        }
    }
}
