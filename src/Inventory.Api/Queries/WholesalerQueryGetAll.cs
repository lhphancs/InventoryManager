using System.Collections.Generic;
using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;
using System.Linq;

namespace Inventory.Api.Queries
{
    public class WholesalerQueryGetAll : IRequest<IEnumerable<WholesalerDto>>
    {
        private readonly string Upc;

        public WholesalerQueryGetAll(string upc)
        {
            Upc = upc;
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

                if (!string.IsNullOrEmpty(request.Upc))
                {
                    query = query.Include(x => x.Products).Where(x => x.Products.Any(y => y.ProductInfo.Upc == request.Upc));
                }
                var wholesalers = await query.ToListAsync();

                var wholesalerDtos = WholesalerMapper.MapToDto(wholesalers);
                return wholesalerDtos;
            }
        }
    }
}
