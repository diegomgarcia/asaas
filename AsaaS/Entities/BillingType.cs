using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace AsaaS.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum BillingType
    {
        BOLETO,
        CREDIT_CARD,
        DEBIT_CARD,
        UNDEFINED,
        TRANSFER,
        DEPOSIT,
        PIX
    }
}