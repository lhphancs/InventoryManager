using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Inventory.Abstraction.Dto;

namespace Inventory.Api.Commands
{
    public class WholesalerCommandUpdateInfo : IRequest
    {
        private readonly int Id;
        private readonly WholesalerInfoDto WholesalerInfoDto;
        public WholesalerCommandUpdateInfo(int id, WholesalerInfoDto wholesalerInfoDto)
        {
            Id = id;
            WholesalerInfoDto = wholesalerInfoDto;
        }

        public class WholesalerCommandUpdateAddressHandler : IRequestHandler<WholesalerCommandUpdateInfo>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandUpdateAddressHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(WholesalerCommandUpdateInfo request, CancellationToken cancellationToken)
            {
                var wholesaler = _context.Wholesalers.FirstOrDefault(x => x.Id == request.Id);
                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.Id}' not found");
                }
                wholesaler.UpdateWholesalerInfo(request.WholesalerInfoDto);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
