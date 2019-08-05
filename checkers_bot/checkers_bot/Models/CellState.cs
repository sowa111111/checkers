using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace checkers_bot
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CellState
    {
        [EnumMember(Value = ".")]
        EmptyCell,
        [EnumMember(Value = "w")]
        WhiteChecker,
        [EnumMember(Value = "W")]
        WhiteQueenChecker,
        [EnumMember(Value = "b")]
        BlackChecker,
        [EnumMember(Value = "B")]
        BlackQueenChecker
    }
}