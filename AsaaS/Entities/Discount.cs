namespace AsaaS.Entities
{
    public class Discount
    {
        public double? Value { get; set; }
        public int DueDateLimitDays { get; set; }
        public DiscountType Type { get; set; }
    }
}