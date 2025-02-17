using Newtonsoft.Json;

namespace Tonnage
{
    public class InlineQuery
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
