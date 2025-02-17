using Newtonsoft.Json;

namespace Tonnage
{
    public class ChatMemberUpdated
    {
        [JsonProperty("chat")]
        public string Chat { get; set; }
    }
}
