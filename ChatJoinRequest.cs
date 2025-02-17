using Newtonsoft.Json;

namespace Tonnage
{
    public class ChatJoinRequest
    {
        [JsonProperty("chat")]
        public string Chat { get; set; }
    }
}
