using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class WholesalerCommandCreate : IRequest<WholesalerDto>
    {
        private readonly WholesalerInfoDto WholesalerInfoDto;
        public WholesalerCommandCreate(WholesalerInfoDto wholesalerInfoDto)
        {
            WholesalerInfoDto = wholesalerInfoDto;
        }

        public class WholesalerCommandCreateHandler : IRequestHandler<WholesalerCommandCreate, WholesalerDto>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandCreateHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<WholesalerDto> Handle(WholesalerCommandCreate request, CancellationToken cancellationToken)
            {
                var existingWholesaler = _context.Wholesalers.FirstOrDefault(x => x.WholesalerInfo.Name == request.WholesalerInfoDto.Name);
                if (existingWholesaler != null)
                {
                    throw new InvalidOperationException($"Duplicate Wholesaler with name: '{request.WholesalerInfoDto.Name}'");
                }

                var wholesaler = new Wholesaler(request.WholesalerInfoDto);
                _context.Wholesalers.Add(wholesaler);

                await _context.SaveChangesAsync(cancellationToken);

                return WholesalerMapper.MapToDto(wholesaler);
            }
        }
    }
}
