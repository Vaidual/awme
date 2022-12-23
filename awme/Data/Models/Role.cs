using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace awme.Data.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {
        User,
        Admin,
        Manager,
    }
}
