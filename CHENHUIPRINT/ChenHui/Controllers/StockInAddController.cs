using ChenHui.Models;
using Domain.Model;
using Newtonsoft.Json;
using Service.ServiceImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChenHui.Controllers
{
    public class StockInAddController : BaseController
    {
        // GET: StockInAdd
        public ActionResult Index()
        {
            var SysFlowNoManage = new SysFlowNoManage();
            var flowNo = SysFlowNoManage.GetFlowNo(FlowNoType.Stock);
            ViewBag.flowNo = DateTime.Now.ToString("yyyyMdd-") + flowNo;
            return View();  
        }
        public ActionResult Save(string data)
        {
            try
            {
                var stockRecord = JsonConvert.DeserializeObject<StockRecord>(data);
                StockRecordManage stockRecordManage = new StockRecordManage();
                var isSuccess = stockRecordManage.Save(stockRecord);
                if (isSuccess)
                {
                    return Json(new SuccessResult("保存成功！"));
                }
                else
                {
                    return Json(new ErrorResult("保存失败！" ));
                }
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, Msg = ex.Message });
            }
        }
    }
}