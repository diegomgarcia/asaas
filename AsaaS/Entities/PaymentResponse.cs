namespace AsaaS.Entities
{
    public class PaymentResponse
    {
        public string Id { get; set; }
        public string DateCreated { get; set; }
        public string Customer { get; set; }
        public string Subscription { get; set; }
        public string Installment { get; set; }
        public string PaymentLink { get; set; }
        public string DueDate { get; set; }
        public double Value { get; set; }
        public double NetValue { get; set; }
        public BillingType BillingType { get; set; }
        public StatusType Status { get; set; } 
        public string Description { get; set; }        
        public string ExternalReference { get; set; }
        public string ConfirmedDate { get; set; }
        public double? OriginalValue { get; set; }
        public double? InterestValue { get; set; }
        public string OriginalDueDate { get; set; }
        public string PaymentDate { get; set; }
        public string ClientPaymentDate { get; set; }
        public string InvoiceUrl { get; set; }
        public string BankSlipUrl { get; set; }
        public string InvoiceNumber { get; set; }
        public bool Deleted { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}