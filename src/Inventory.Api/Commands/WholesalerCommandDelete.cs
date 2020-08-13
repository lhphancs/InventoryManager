using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Inventory.Api.Commands
{
    public class WholesalerCommandDelete : IRequest
    {
        private readonly int Id;
        public WholesalerCommandDelete(int id)
        {
            Id = id;
        }

        public class WholesalerCommandDeleteHandler : IRequestHandler<WholesalerCommandDelete>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandDeleteHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(WholesalerCommandDelete request, CancellationToken cancellationToken)
            {
                var wholesaler = _context.Wholesalers.FirstOrDefault(x => x.Id == request.Id);
                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.Id}' not found");
                }
                _context.Wholesalers.Remove(wholesaler);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
