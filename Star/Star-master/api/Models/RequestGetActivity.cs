using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class RequestGetActivity: RequestBase
    {
        public int page { get; set; } = 1;
    }
}