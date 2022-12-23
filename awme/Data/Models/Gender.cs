using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace awme.Data.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
