using MediatR;
using System;

namespace Inventory.Api.Events
{
    public class ProductQuantityChangeEvent : INotification
    {
        public string Upc { get; }
        public string Company { get; }
        public int QuantityChange { get; }
        public DateTime Timestamp { get; }
    }
}
