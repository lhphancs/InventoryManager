using Inventory.Abstraction.Models;
using Inventory.Api.Aggregates.Shelf;
using System;

namespace Inventory.Api.Aggregates
{
    public class Product
    {
        public Product(ProductInformation model)
        {
            UpdateProductInformation(model);

            CreatedDateTime = DateTime.UtcNow;
            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateProductInformation(ProductInformation model)
        {
            Upc = model.Upc;
            Brand = model.Brand;
            Name = model.Name;
            Description = model.Description;
            ExpirationLocation = model.ExpirationLocation;
            ImageUrl = model.ImageUrl;
            OunceWeight = model.OunceWeight;
            RequiresPadding = model.RequiresPadding;
            RequiresBubbleWrap = model.RequiresBubbleWrap;

            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public string Upc { get; private set; }
        public string Brand { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ExpirationLocation { get; private set; }
        public string ImageUrl { get; private set; }
        public int OunceWeight { get; private set; }

        public bool RequiresPadding { get; private set; }
        public bool RequiresBubbleWrap { get; private set; }

        public int Quantity { get; private set; }
        public Guid? ShelfLocationId { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }

        public ShelfLocation ShelfLocation { get; private set; }

    }
}
