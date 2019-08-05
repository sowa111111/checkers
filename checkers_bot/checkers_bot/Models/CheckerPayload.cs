using Newtonsoft.Json;

namespace checkers_bot
{
    public class CheckerPayload
    {
        [JsonProperty("team")]
        public Team Team { get; set; }

        [JsonProperty("field")]
        public CellState[][] Field { get; set; }
    }
}
