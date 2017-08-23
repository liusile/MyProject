using Service.Iservice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Models;
using Domain.Models.Common;
using System.Web.Security;

namespace Service.ServiceImp.Common
{ 
    public class UserManage : RepositoryBase<User>, IUser
    {

        public bool Login(string userName, string pwd)
        {
            return this.IsExist(o => o.UserName == userName && o.Pwd == pwd);
        }
       
    }
}
