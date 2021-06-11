using System.Text.Json.Serialization;

namespace AsaaS.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusType
    {
        PENDING,
        RECEIVED,
        CONFIRMED,
        OVERDUE,
        REFUNDED,
        RECEIVED_IN_CASH,
        REFUND_REQUEST,
        CHARGEBACK_REQUESTED,
        CHARGEBACK_DISPUTE,
        AWAITING_CHARGEBACK_REVERSAL,
        DUNNING_REQUESTED,
        DUNNING_RECEIVED,
        AWAITING_RISK_ANALYSIS
    }
}