using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class RequestRegister
    {
        public string UserName { get; set; }
        public string Pwd { get; set; }
        /// <summary>
        /// 头像默认头像,默认：待确定
        /// </summary>
        public string HeadImgUrl { get; set; }
        // public string HeadImgUrl { get; set; }=imgurl
        public string Email { get; set; }
    }
}