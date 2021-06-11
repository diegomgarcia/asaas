
namespace AsaaS.Entities
{
    public class Subscription
    {
        public string Id { get; set; }
        public string DateCreated { get; set; }
        public string Customer { get; set; }
        public BillingType BillingType { get; set; }
        public double Value { get; set; }
        public string NextDueDate { get; set; }
        public Discount Discount { get; set; }
        public Interest Interest { get; set; }
        public Fine Fine { get; set; }
        public CycleType Cycle { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
        public string MaxPayments { get; set; }
        public string ExternalReference { get; set; }
        public string PaymentLink { get; set; }
        public bool? Deleted { get; set; }
    }
}