using System;

namespace Inventory.Api.ValueObjects
{
    public class ProductQuantityChangeInfo
    {
        ProductQuantityChangeInfo() { }
        public ProductQuantityChangeInfo(string upc, string companyName, int quantityChangeAmt)
        {
            if (string.IsNullOrWhiteSpace(upc))
            {
                throw new InvalidOperationException("upc cannot be blank");
            }

            if (string.IsNullOrWhiteSpace(companyName))
            {
                throw new InvalidOperationException("companyName cannot be blank");
            }

            if (quantityChangeAmt <= 0)
            {
                throw new InvalidOperationException("quantityChangeAmt must be positive");
            }
        }
        public string Upc { get; set; }
        public string CompanyName { get; set; }
        public int QuantityChangeAmt { get; set; }
    }
}
