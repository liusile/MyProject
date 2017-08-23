using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Common
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Display(Name = "密码")]
        public string Pwd { get; set; }

        [Display(Name = "头像地址")]
        public string HeadImgUrl { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        

        [Display(Name = "是否生效")]
        public bool IsValid { get; set; }

    }
}
