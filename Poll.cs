using Newtonsoft.Json;

namespace Tonnage
{
    public class Poll
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
