using MediatR;
using Inventory.Api.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Inventory.Abstraction.Dto;
using Inventory.Api.ValueObjects;

namespace Inventory.Api.Commands
{
    public class WholesalerCommandUpdateAddress : IRequest
    {
        private readonly int Id;
        private readonly Address Address;
        public WholesalerCommandUpdateAddress(int id, AddressDto addressDto)
        {
            Id = id;
            Address = new Address(addressDto.City, addressDto.Street, addressDto.ZipCode);
        }

        public class WholesalerCommandUpdateAddressHandler : IRequestHandler<WholesalerCommandUpdateAddress>
        {
            private readonly InventoryContext _context;

            public WholesalerCommandUpdateAddressHandler(InventoryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(WholesalerCommandUpdateAddress request, CancellationToken cancellationToken)
            {
                var wholesaler = _context.Wholesalers.FirstOrDefault(x => x.Id == request.Id);
                if (wholesaler == null)
                {
                    throw new InvalidOperationException($"WholesalerId '{request.Id}' not found");
                }
                wholesaler.UpdateAddress(request.Address);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
