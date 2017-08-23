using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class RequestAddProductType:RequestBase
    {
        public string ProductTypeName { get; set; }
        public int ParentProductTypeId { get; set; } = 0;

    }
}