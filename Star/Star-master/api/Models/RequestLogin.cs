using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class RequestLogin
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string Signature { get; set; }
        public string TimeStamp { get; set; }
        public string Nonce { get; set; }
        public string Appid { get; set; }
    }
}