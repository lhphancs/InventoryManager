using Inventory.Api.Events.DomainEvents;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.Api.DomainEventHandlers
{
    public class ProductQuantityChangeEventHandler : INotificationHandler<ProductQuantityChangeEvent>
    {
        public ProductQuantityChangeEventHandler()
        {
        }

        public async Task Handle(ProductQuantityChangeEvent changeEvent, CancellationToken cancellationToken)
        {
            Console.WriteLine("AA");
        }
    }
}
