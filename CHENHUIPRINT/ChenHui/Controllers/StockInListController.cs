using Service.ServiceImp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Domain.Model;
using Newtonsoft.Json;
using ChenHui.Models;

namespace ChenHui.Controllers
{
    public class StockInListController : BaseController
    {
        StockRecordManage stockRecordManage = new StockRecordManage();
        // GET: StockInList
        public ActionResult Index()
        {
            return View();
        }
        //
        public ActionResult ListData(int offset,int limit,DateTime? DateS,DateTime? DateE, string Supplier, string StockRecordNo,string StorageManager)
        {
            var condition = SearchConditon(  DateS,  DateE,  Supplier,  StockRecordNo,  StorageManager);

            var list = stockRecordManage.LoadAll(o => true)
                .Include("Product")
                .AsNoTracking()
                .Where(condition)
                .SelectMany(r => r.Product, (r, p) =>
                new
                {
                    r.Id,
                    r.StockRecordNo,
                    p.ProductType,
                    p.ProductSubType,
                    p.Brand,
                    p.Spec,
                    p.Grammage,
                    p.TonOfPrice,
                    p.UnitPrice,
                    p.Num,
                    r.Supplier,
                    r.StorageManager,
                    r.CreateTime,
                    r.OperPeople,
                })
                .OrderByDescending(o => o.Id);
            return Json(new { total = list.Count(), rows = list.Skip(offset).Take(limit) });
        } 
        private Func<StockRecord, bool>  SearchConditon( DateTime? DateS, DateTime? DateE, string Supplier, string StockRecordNo, string StorageManager)
        {
            Func<StockRecord, bool> condition = (o) => true;
            if (DateS != null)
            {
                condition += (o) => o.CreateTime >= DateS;
            }
            if (DateE != null)
            {
                condition += (o) => o.CreateTime < Convert.ToDateTime(DateE).AddDays(1);
            }
            if (!string.IsNullOrWhiteSpace(Supplier))
            {
                condition += (o) => o.Supplier == Supplier;
            }
            if (!string.IsNullOrWhiteSpace(StockRecordNo))
            {
                condition += (o) => o.StockRecordNo == StockRecordNo;
            }
            if (!string.IsNullOrWhiteSpace(StorageManager))
            {
                condition += (o) => o.StorageManager == StorageManager;
            }
            return condition;
        }  

        public ActionResult Delete(string StockRecordNo)
        {
            var entity = stockRecordManage.LoadAll(o => o.StockRecordNo == StockRecordNo).Include("Product").FirstOrDefault();
            var isSuccess = stockRecordManage.Delete(entity);
            if (isSuccess)
            {
                return Json(new SuccessResult($"入库单：{StockRecordNo}删除成功！" ));
            }
            else
            {
                return Json(new ErrorResult( $"入库单：{StockRecordNo}删除失败！" ));
            }
        }
    }
}