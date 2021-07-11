using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using Inventory.Api.Mappers;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class WholesalerCommandUpdateInfo : IRequest<WholesalerDto>
    {
        private readonly int Id;
        private readonly WholesalerInfoDto WholesalerInfoDto;
        public WholesalerCommandUpdateInfo(int id, WholesalerInfoDto wholesalerInfoDto)
        {
            Id = id;
            WholesalerInfoDto = wholesalerInfoDto;
        }

        public class WholesalerCommandUpdateAddressHandler : IRequestHandler<WholesalerCommandUpdateInfo, WholesalerDto>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandUpdateAddressHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<WholesalerDto> Handle(WholesalerCommandUpdateInfo request, CancellationToken cancellationToken)
            {
                var wholesaler = _context.Wholesalers.FirstOrDefault(x => x.Id == request.Id);
                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.Id}' not found");
                }
                wholesaler.UpdateWholesalerInfo(request.WholesalerInfoDto);
                await _context.SaveChangesAsync(cancellationToken);

                return WholesalerMapper.MapToDto(wholesaler);
            }
        }
    }
}
