using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace checkers_bot
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Team
    {
        [EnumMember(Value = "w")]
        White,
        [EnumMember(Value = "b")]
        Black
    }
}