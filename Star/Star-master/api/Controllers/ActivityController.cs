using api.Models;
using Domain.Models.PermanentAssets;
using Service.ServiceImp.Common;
using Service.ServiceImp.PermanentAssets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace api.Controllers
{
    public class ActivityController : ApiController
    {
        [HttpGet, HttpPost]
        public string Test()
        {
            return "Test Success";
        }
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost, System.Web.Http.HttpGet]
        public IHttpActionResult AddActivity([FromBody]RequestAddActivity request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var bll = new ActivityBLL();
            var Activity = new Activity()
            {
                UserName = tokenResult.userName,
                Remark = request.Remark,
                Subject = request.Subject,
                Time=request.Time
            };
            bool isSuccess = bll.Save(Activity);
            return Json(new ResponseMsg() { IsSuccess = isSuccess });
        }

        /// <summary>
        /// 获取活动列表
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost, System.Web.Http.HttpGet]
        public IHttpActionResult GetActivity([FromBody]RequestGetActivity request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var bll = new ActivityBLL();
            var data = bll.LoadAll(o=>o.UserName==tokenResult.userName).OrderByDescending(o=>o.Time).Skip(10 * (request.page - 1)).Take(10);
            return Json(data);
        }
        /// <summary>
        /// 获取活动明细
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost, System.Web.Http.HttpGet]
        public IHttpActionResult GetActivityDetail([FromBody]RequestGetActivityDetail request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var bll = new ActivityBLL();
            var data = bll.Get(o => o.UserName == tokenResult.userName && o.ActivityId==request.ActivityId);
            return Json(data);
        }
        /// <summary>
        /// 删除活动
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost, System.Web.Http.HttpGet]
        public IHttpActionResult GetActivityDel([FromBody]RequestGetActivityDetail request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var bll = new ActivityBLL();
            var isSuccess = bll.Delete(o => o.UserName == tokenResult.userName && o.ActivityId == request.ActivityId);
            return Json(new { isSuccess= isSuccess });
        }
    }
}