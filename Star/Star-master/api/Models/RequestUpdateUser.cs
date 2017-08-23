using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class RequestUpdateUser:RequestBase
    {
        public string Pwd { get; set; }
        public string HeadImgUrl { get; set; }
    }
}