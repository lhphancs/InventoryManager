using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Queries
{
    public class WholesalerQueryGetAll : IRequest<IEnumerable<WholesalerDto>>
    {
        private readonly int? ProductId;

        public WholesalerQueryGetAll(int? productId)
        {
            ProductId = productId;
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
                var query = _context.Wholesalers.AsQueryable();

                if (request.ProductId != null)
                {
                    query = query.Where(x => x.ProductWholesalers.Any(y => y.ProductId == (int)request.ProductId));
                }
                query = query.Include(x => x.ProductWholesalers).ThenInclude(x => x.Product);

                var wholesalers = await query.ToListAsync();

                var wholesalerDtos = WholesalerMapper.MapToDto(wholesalers);
                return wholesalerDtos;
            }
        }
    }
}
