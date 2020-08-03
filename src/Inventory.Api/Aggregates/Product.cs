﻿using Inventory.Abstraction.Dto;
using Inventory.Api.Aggregates.Shelf;
using Inventory.Api.SeedWork;
using Inventory.Api.ValueObjects;
using System;

namespace Inventory.Api.Aggregates
{
    public class Product : Entity
    {
        public Product() { }

        public Product(ProductDto productDto)
        {
            Upc = productDto.Upc;
            UpdateProductInfo(productDto.ProductInfo);
            UpdateProductPreparationInfo(productDto.ProductPreparationInfo);

            Quantity = productDto.Quantity;

            CreatedDateTime = DateTime.UtcNow;
            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateProductInfo(ProductInfoDto productInfoDto)
        {
            ProductInfo = new ProductInfo(productInfoDto);

            ModifiedDateTime = CreatedDateTime;
        }

        public void UpdateProductPreparationInfo(ProductPreparationInfoDto productPreparationInfoDto)
        {
            ProductPreparationInfo = new ProductPreparationInfo(productPreparationInfoDto);

            ModifiedDateTime = CreatedDateTime;
        }

        public void RecieveIn(ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            ChangeQuantityAmt(productQuantityChangeInfo.CompanyName, productQuantityChangeInfo.QuantityChangeAmt);
        }

        public void ShipOut(ProductQuantityChangeInfo productQuantityChangeInfo)
        {
            ChangeQuantityAmt(productQuantityChangeInfo.CompanyName, -productQuantityChangeInfo.QuantityChangeAmt);
        }


        public void AssignNewShelfLocation(Guid shelfLocationId)
        {
            ShelfLocationId = shelfLocationId;
        }

        private void ChangeQuantityAmt(string companyName, int changeAmt)
        {
            Quantity += changeAmt;

            // Send msg to store in audit table
            ModifiedDateTime = CreatedDateTime;

            //AddDomainEvent();
        }

        public string Upc { get; private set; }
        public ProductInfo ProductInfo { get; private set; }
        public ProductPreparationInfo ProductPreparationInfo { get; private set; }

        public int Quantity { get; private set; }
        public Guid? ShelfLocationId { get; private set; }

        public DateTime CreatedDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }

        public virtual ShelfLocation ShelfLocation { get; private set; }
    }
}
