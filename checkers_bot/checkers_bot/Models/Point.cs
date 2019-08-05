using Newtonsoft.Json;
using System;

namespace checkers_bot
{
    public class Point
    {
        public Point(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        [JsonProperty("x")]
        public Byte X { get; set; }

        [JsonProperty("y")]
        public Byte Y { get; set; }
    }
}