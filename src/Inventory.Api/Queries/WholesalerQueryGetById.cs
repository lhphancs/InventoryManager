using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

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
                var wholesaler = await _context.Wholesalers.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.Id}' not found");
                }

                var WholesalerDto = WholesalerMapper.MapToDto(wholesaler);
                return WholesalerDto;
            }
        }
    }
}
