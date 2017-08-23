using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChenHui.Models
{
    public class SuccessResult
    {
        public bool IsSuccess { get; set; } = true;
        public string Msg { get; internal set; }
        public SuccessResult(string msg)
        {
            Msg = msg;
        }
    }
}