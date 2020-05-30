

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Document.Library.Globals.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Permission
    {
        None = 0,
        Read = 1,
        Write = 2,
        Full = 3,
    }
}
