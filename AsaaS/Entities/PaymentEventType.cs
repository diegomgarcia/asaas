using System.Text.Json.Serialization;

namespace AsaaS.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum PaymentEventType
    {
        PAYMENT_CREATED,
        PAYMENT_UPDATED,
        PAYMENT_CONFIRMED,
        PAYMENT_RECEIVED,
        PAYMENT_OVERDUE,
        PAYMENT_DELETED,
        PAYMENT_RESTORED,
        PAYMENT_REFUNDED,
        PAYMENT_RECEIVED_IN_CASH_UNDONE,
        PAYMENT_CHARGEBACK_REQUESTED,
        PAYMENT_AWAITING_CHARGEBACK_REVERSAL,
        PAYMENT_DUNNING_RECEIVED,
        PAYMENT_DUNNING_REQUESTED
    }
}