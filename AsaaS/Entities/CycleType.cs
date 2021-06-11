using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AsaaS.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CycleType
    {
        WEEKLY,
        BIWEEKLY,
        MONTHLY,
        QUARTERLY,
        SEMIANNUALLY,
        YEARLY
    }
}