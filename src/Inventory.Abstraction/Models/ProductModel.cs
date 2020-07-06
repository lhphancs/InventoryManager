using Newtonsoft.Json;
using System;

namespace Inventory.Abstraction.Models
{
    public class ProductModel
    {
        [JsonProperty("upc", NullValueHandling = NullValueHandling.Ignore)]
        public string Upc { get; set; }

        [JsonProperty("brand", NullValueHandling = NullValueHandling.Ignore)]
        public string Brand { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("expiration_location", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpirationLocation { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("ounce_weight", NullValueHandling = NullValueHandling.Ignore)]
        public int OunceWeight { get; set; }

        [JsonProperty("requires_padding", NullValueHandling = NullValueHandling.Ignore)]
        public bool RequiresPadding { get; set; }

        [JsonProperty("requires_bubblewrap", NullValueHandling = NullValueHandling.Ignore)]
        public bool RequiresBubbleWrap { get; set; }

        [JsonProperty("shelf_location_id", NullValueHandling = NullValueHandling.Ignore)]
        public Guid ShelfLocationId { get; set; }

        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public int Quantity { get; set; }

        [JsonProperty("shelf_locations", NullValueHandling = NullValueHandling.Ignore)]
        public ShelfLocationModel ShelfLocation { get; set; }
    }
}
