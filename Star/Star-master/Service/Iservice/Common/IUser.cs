using Domain.Models.Common;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service.Iservice.Common
{
    public interface IUser : IRepository<User>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户登录名称</param>
        /// <param name="pwd">用户密码</param>
        /// <returns></returns>
        bool Login(string userName,string pwd);

    }
}
