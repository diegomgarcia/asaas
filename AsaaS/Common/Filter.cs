namespace AsaaS.Common
{
    //TODO: Implement search filters for custom searchs
    public class Filter
    {
        public string Id { get; set; }
        public int? Limit { get; set; }
        public int? Offset { get; set; }
    }
}