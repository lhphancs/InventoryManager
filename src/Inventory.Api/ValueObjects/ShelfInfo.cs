using Inventory.Abstraction.Dto;
using Inventory.Api.Infrastructure;
using System.Collections.Generic;

namespace Inventory.Api.ValueObjects
{
    public class ShelfInfo : ValueObject
    {
        public ShelfInfo() { }

        public ShelfInfo(ShelfInfoDto ShelfInfoDto)
        {
            Name = ShelfInfoDto.Name;
            Description = ShelfInfoDto.Description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Description;
        }
    }
}
