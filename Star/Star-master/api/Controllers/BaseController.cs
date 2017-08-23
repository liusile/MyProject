using Domain.Models.Common;
using Service.Models;
using Service.ServiceImp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using api.Models;

namespace api.Controllers
{
    public class BaseController : ApiController
    {
        [HttpGet, HttpPost]
        public string Test()
        {
            return "Test Success";
        }
        [HttpGet, HttpPost]
        public IHttpActionResult TestSQL()
        {
            var userBll = new UserManage();
            var result = userBll.LoadAll(o => true);
            return Json(result);
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet,HttpPost]
        public IHttpActionResult Login([FromBody]RequestLogin request)
        {
            var userBll=new UserManage();
            var tokenResult = new TokenResult();
            var isSuccess = IdentityValid.ValidateSignature(request.Signature, request.TimeStamp, request.Nonce, request.Appid);
            if (isSuccess)
            {
                if (userBll.Login(request.UserName, request.Pwd))
                {
                    tokenResult.token = IdentityValid.CreateToken(request.UserName, request.Appid);
                    tokenResult.IsSuccess = true;
                }
                else
                {
                    tokenResult.IsSuccess = false;
                    tokenResult.Msg = "用户密码错误！";
                }
            }
            else
            {
                tokenResult.IsSuccess = false;
                tokenResult.Msg = "签名验证失败！";
            }
            return Json(tokenResult);
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet,HttpPost]
        public IHttpActionResult Register([FromBody]RequestRegister request)
        {
            var userBll = new UserManage();
            var user = new User()
            {
                IsValid=true,
                HeadImgUrl= request.HeadImgUrl,
                Pwd= request.Pwd,
                UserName=request.UserName,
                Email=request.Email
            };
            bool isSuccess=userBll.Save(user);
            return Json(new ResponseMsg() {IsSuccess=isSuccess});
        }
        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet, HttpPost]
        [UserAuthorizeAttribute]
        public IHttpActionResult UpdateUser(RequestUpdateUser request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var userBll = new UserManage();
            var user = userBll.Get(o => o.UserName == tokenResult.userName);
            user.HeadImgUrl = request.HeadImgUrl;
            user.Pwd = request.Pwd;
            bool isSuccess = userBll.Update(user);
            return Json(new ResponseMsg() { IsSuccess = isSuccess });
        }
        /// <summary>
        /// 第三方注册
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet,HttpPost]
        public IHttpActionResult RegisterOauth([FromBody]RequestRegisterOauth request)
        {
            var tokenResult = new TokenResult();
            var isSuccess = IdentityValid.ValidateSignature(request.Signature, request.TimeStamp, request.Nonce, request.Appid);
            if (isSuccess)
            {
                var userBll = new UserManage();
                var user = new User()
                {
                    IsValid = true,
                    HeadImgUrl = string.Empty,
                    Pwd = string.Empty,
                    UserName = request.UserName,
                    Email = string.Empty
                };
                if (userBll.IsExist(o => o.UserName == request.UserName))
                {
                    tokenResult.IsSuccess = true;
                    tokenResult.token = IdentityValid.CreateToken(request.UserName, request.Appid);
                    return Json(tokenResult);
                }
                else
                {
                    tokenResult.IsSuccess = userBll.Save(user);
                    tokenResult.token = IdentityValid.CreateToken(request.UserName, request.Appid);
                    return Json(tokenResult);
                }
            }
            else
            {
                return Json(new ResponseMsg() { IsSuccess = false,Msg= "签名验证失败！" });
            }
        }
        
    }
}

