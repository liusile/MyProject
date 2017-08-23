using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class RequestGetProductType:RequestBase
    {
        public int ParentProductTypeId { get; set; }
    }
}