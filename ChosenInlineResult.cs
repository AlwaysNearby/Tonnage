using Newtonsoft.Json;

namespace Tonnage
{
    public class ChosenInlineResult
    {
        [JsonProperty("result_id")]
        public string ResultId { get; set; }
    }
}
