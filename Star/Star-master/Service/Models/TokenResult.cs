using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class TokenResult
    {
        public string token { get; set; }
        public bool IsSuccess { get; set; }
        public string Msg { get; set; }
        public string userName { get; set; }
        public string appid { get; set; }
    }
}
