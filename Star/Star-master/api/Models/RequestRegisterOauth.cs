namespace api.Models
{
   public class RequestRegisterOauth:RequestBase
    {
        public string UserName { get; set; }
        public string Signature { get; set; }
        public string TimeStamp { get; set; }
        public string Nonce { get; set; }
        public string Appid { get; set; }
    }
}