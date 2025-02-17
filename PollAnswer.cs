using Newtonsoft.Json;

namespace Tonnage
{
    public class PollAnswer
    {
        [JsonProperty("poll_id")]
        public string PollId { get; set; }
    }
}
