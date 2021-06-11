using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AsaaS.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DiscountType
    {
        [EnumMember(Value = "FIXED")]
        FIXED,
        [EnumMember(Value = "PERCENTAGE")]
        PERCENTAGE
    }
}