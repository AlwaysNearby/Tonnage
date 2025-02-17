using Newtonsoft.Json;

namespace Tonnage
{
    public class CallbackQuery
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
