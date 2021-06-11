using System.Text.Json.Serialization;

namespace AsaaS.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DiscountType
    {
        FIXED,
        PERCENTAGE
    }
}