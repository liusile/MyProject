using Service.ServiceImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Model;

namespace ChenHui.Controllers
{
    public class HomeController : Controller
    {
        public UserInfoManage UserInfoManageBz = new UserInfoManage();
        public ActionResult Index()
        {
            //UserInfoManageBz.Save(new UserInfo()
            //{
            //    UserCode = "123",
            //    UserName = "TestUserName"
            //});
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}