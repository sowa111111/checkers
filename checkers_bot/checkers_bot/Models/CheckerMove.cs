using Newtonsoft.Json;

namespace checkers_bot
{
    public class CheckerMove
    {
        [JsonProperty("from")]
        public Point FromPoint { get; set; }

        [JsonProperty("to")]
        public Point ToPoint { get; set; }
    }
}