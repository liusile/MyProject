namespace api.Models
{
    public class RequestGetProduct:RequestBase
    {
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
    }
}