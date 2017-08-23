using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChenHui.Models
{
    public class ErrorResult
    {
        public bool IsSuccess { get; set; } = false;
        public string Msg { get; internal set; }
        public ErrorResult(string msg)
        {
            Msg = msg;
        }
    }
}