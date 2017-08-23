using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChenHui.Controllers
{
    public class BaseController : Controller
    {
        public new  ActionResult Json(object data)
        {
            var result = JsonConvert.SerializeObject(data, Formatting.None,
                new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }
            );
            return Content(result) ;
        }
    }
}