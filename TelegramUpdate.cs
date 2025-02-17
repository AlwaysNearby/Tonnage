using Newtonsoft.Json;

namespace Tonnage
{
    internal class TelegramUpdate
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("result")]
        public Update[] Result { get; set; }
    }
}
