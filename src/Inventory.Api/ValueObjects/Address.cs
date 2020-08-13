using Inventory.Api.Infrastructure;
using System.Collections.Generic;

namespace Inventory.Api.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public string Street { get; }
        public string City { get; }
        public string ZipCode { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;
        }
    }
}
