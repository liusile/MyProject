using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class RequestAddActivity : RequestBase
    {
        public string Remark { get;  set; }
        public string Subject { get;  set; }
        public DateTime Time { get;  set; }
    }
}