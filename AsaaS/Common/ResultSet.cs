using System.Collections.Generic;

namespace AsaaS.Common
{
    public class ResultSet<T> where T: class 
    {
        public bool HasMore { get; set; }
        public int TotalCount { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        
        public List<T> Data { get; set; }
    }
}