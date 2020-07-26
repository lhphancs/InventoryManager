using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using System;

namespace Inventory.Api.Aggregates
{
    public class Product
    {
        public Product() { }

        public Product(ProductDto productDto)
        {
            UpdateProduct(productDto);

            CreatedDateTime = DateTime.UtcNow;
            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateProduct(ProductDto productDto)
        {
            Upc = productDto.Upc;
            Brand = productDto.Brand;
            Name = productDto.Name;
            Description = productDto.Description;
            ExpirationLocation = productDto.ExpirationLocation;
            ImageUrl = productDto.ImageUrl;
            OunceWeight = productDto.OunceWeight;
            RequiresPadding = productDto.RequiresPadding;
            RequiresBubbleWrap = productDto.RequiresBubbleWrap;
            Quantity = productDto.Quantity;
            ModifiedDateTime = CreatedDateTime;
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

        public virtual ShelfLocation ShelfLocation { get; private set; }
    }
}
