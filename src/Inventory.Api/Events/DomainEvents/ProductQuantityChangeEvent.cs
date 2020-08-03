using MediatR;
using System;

namespace Inventory.Api.Events.DomainEvents
{
    public class ProductQuantityChangeEvent : INotification
    {
        public ProductQuantityChangeEvent(int productId, string company, int quantityChange, DateTime timestamp)
        {
            ProductId = productId;
            Company = company;
            QuantityChange = quantityChange;
            Timestamp = timestamp;
        }
        public int ProductId { get; }
        public string Company { get; }
        public int QuantityChange { get; }
        public DateTime Timestamp { get; }
    }
}
