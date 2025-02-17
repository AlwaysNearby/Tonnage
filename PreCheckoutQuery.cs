using Newtonsoft.Json;

namespace Tonnage
{
    public class PreCheckoutQuery
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
