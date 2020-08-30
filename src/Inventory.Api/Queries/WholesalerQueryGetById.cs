using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory.Abstraction.Dto;
using Inventory.Api.Mappers;

namespace Inventory.Api.Queries
{
    public class WholesalerQueryGetById : IRequest<WholesalerDto>
    {
        private readonly int Id;
        public WholesalerQueryGetById(int id)
        {
            Id = id;
        }

        public class WholesalerGetByUpcQueryHandler : IRequestHandler<WholesalerQueryGetById, WholesalerDto>
        {
            private readonly InventoryContext _context;

            public WholesalerGetByUpcQueryHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<WholesalerDto> Handle(WholesalerQueryGetById request, CancellationToken cancellationToken)
            {
                var Wholesaler = await _context.Wholesalers.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == request.Id);
                var WholesalerDto = WholesalerMapper.MapToDto(Wholesaler);
                return WholesalerDto;
            }
        }
    }
}
