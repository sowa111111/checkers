using Newtonsoft.Json;
using System;

namespace checkers_bot
{
    public class CellPoint
    {
        public CellPoint(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        [JsonProperty("x")]
        public Byte X { get; set; }

        [JsonProperty("y")]
        public Byte Y { get; set; }

        public static bool IsValidCellPoint(int x, int y)
            => x >= 0 && x <= 7 && y >= 0 && y <= 7;
    }
}