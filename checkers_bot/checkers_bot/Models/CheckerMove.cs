using Newtonsoft.Json;

namespace checkers_bot
{
    public class CheckerMove
    {
        [JsonProperty("from")]
        public CellPoint FromPoint { get; set; }

        [JsonProperty("to")]
        public CellPoint ToPoint { get; set; }
    }
}