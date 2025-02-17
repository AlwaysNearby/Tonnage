using Newtonsoft.Json;

namespace Tonnage
{
    public class ShippingQuery
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
