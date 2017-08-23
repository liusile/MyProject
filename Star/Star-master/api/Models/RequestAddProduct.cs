namespace api.Models
{
    public class RequestAddProduct:RequestBase
    {
        public string Introduce { get; set; }
        public string ProductImgUrl { get; set; }
        public string ProductName { get; set; }
        public string ProductTypeName { get; set; }
        public string Remark { get; set; }
               
    }
}