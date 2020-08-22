using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates;
using Inventory.Api.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.Commands
{
    public class WholesalerCommandCreate : IRequest
    {
        private readonly WholesalerInfoDto WholesalerInfoDto;
        public WholesalerCommandCreate(WholesalerInfoDto wholesalerInfoDto)
        {
            WholesalerInfoDto = wholesalerInfoDto;
        }

        public class WholesalerCommandCreateHandler : IRequestHandler<WholesalerCommandCreate>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandCreateHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(WholesalerCommandCreate request, CancellationToken cancellationToken)
            {
                var wholesaler = new Wholesaler(request.WholesalerInfoDto);
                _context.Wholesalers.Add(wholesaler);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
