namespace AsaaS.Entities
{
    public class PaymentEvent
    {
        public PaymentEventType Event { get; set; }
        public PaymentResponse Payment { get; set; }
    }
}