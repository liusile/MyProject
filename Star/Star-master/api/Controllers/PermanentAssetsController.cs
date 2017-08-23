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
    /// <summary>
    /// 固定资产管理
    /// </summary>
    public class PermanentAssetsController : ApiController
    {
        /// <summary>
        /// 获取物品类别
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public IHttpActionResult GetProductType(RequestGetProductType request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var bll = new ProductTypeBLL();
            var entity = bll.LoadAll(o => o.UserName == tokenResult.userName);
            //if (request.ParentProductTypeId > 0)
            //{
            //    entity = entity.Where(o => o.ParentProductTypeId == request.ParentProductTypeId);
            //}
            return Json<List<ProductType>>(entity.ToList());
        }
        /// <summary>
        /// 添加物品类别
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public IHttpActionResult AddProductType(RequestAddProductType request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var bll = new ProductTypeBLL();
            var productType = new ProductType()
            {
                UserName = tokenResult.userName,
                ParentProductTypeId = request.ParentProductTypeId,
                ProductTypeName=request.ProductTypeName
            };
            bool isSuccess = bll.Save(productType);
            return Json(new ResponseMsg() {IsSuccess = isSuccess });
        }
        /// <summary>
        /// 删除物品类别
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public IHttpActionResult DelProductType(RequestDelProductType request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var productTypeBll = new ProductTypeBLL();
            var productBll = new ProductBLL();
            if (productBll.IsExist(o => o.UserName == tokenResult.userName && o.ProductTypeId == request.ProductTypeId))
            {
                return Json(new ResponseMsg() { IsSuccess = false,Msg="该物品类别下有物品，不可删除！" });
            }
            if (productTypeBll.IsExist(o => o.ParentProductTypeId == request.ProductTypeId))
            {
                return Json(new ResponseMsg() { IsSuccess = false, Msg = "请先删除子类别！" });
            }
            bool isSuccess = productTypeBll.Delete(o=>o.UserName==tokenResult.userName && o.ProductTypeId==request.ProductTypeId);

            return Json(new ResponseMsg() { IsSuccess = isSuccess });
        }
        /// <summary>
        /// 获取物品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public IHttpActionResult GetProduct(RequestGetProduct request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var bll = new ProductBLL();
            var entity = bll.LoadAll(o => o.UserName == tokenResult.userName);
            if (request.ProductTypeId > 0)
            {
                entity = entity.Where(o => o.ProductTypeId == request.ProductTypeId);
            }
            if (!string.IsNullOrWhiteSpace(request.ProductName))
            {
                entity = entity.Where(o=>o.ProductName.Contains(request.ProductName));
            }
            return Json<List<Product>>(entity.ToList());
        }
        /// <summary>
        /// 添加物品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        private IHttpActionResult AddProduct(RequestAddProduct request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var productbll = new ProductBLL();
            var productTypebll = new ProductTypeBLL();
            var productTypeModel = productTypebll.Get(o => o.ProductTypeName == request.ProductTypeName && o.UserName==tokenResult.userName);
            if (productTypeModel==null)
            {
                productTypebll.Save(new ProductType
                {
                    ParentProductTypeId = 0,
                    UserName = tokenResult.userName,
                    ProductTypeName = request.ProductTypeName
                });
                productTypeModel= productTypebll.Get(o => o.ProductTypeName == request.ProductTypeName && o.UserName == tokenResult.userName);
            }
            
            var product = new Product()
            {
               UserName = tokenResult.userName,
               Introduce= request.Introduce,
               ProductImgUrl= request.ProductImgUrl,
               ProductName= request.ProductName,
               ProductTypeId= productTypeModel.ProductTypeId,
               Remark = request.Remark
            };
            bool isSuccess = productbll.Save(product);
            return Ok(new ResponseMsg() { IsSuccess = isSuccess });
        }
        /// <summary>
        /// 删除物品
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, HttpGet]
        public IHttpActionResult DelProduct(RequestDelProduct request)
        {
            var tokenResult = IdentityValid.ValidateToken(request.Token);
            if (!tokenResult.IsSuccess)
            {
                return Json(tokenResult);
            }

            var productBll = new ProductBLL();
          
            bool isSuccess = productBll.Delete(o => o.UserName == tokenResult.userName && o.ProdcutId == request.ProdcutId);

            return Json(new ResponseMsg() { IsSuccess = isSuccess });
        }
        [HttpPost, HttpGet]
        public async Task<IHttpActionResult> AddProductImg()
        {
            var request = new RequestAddProduct();
            
            if (!Request.Content.IsMimeMultipartContent())
            {
                return Ok(new ResponseMsg() { IsSuccess = false });
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string root = HttpContext.Current.Server.MapPath("~/User");//指定要将文件存入的服务器物理位置  
            var provider = new CustomMultipartFormDataStreamProvider(root);
           
            try
            {
                // Read the form data.  
                await  Request.Content.ReadAsMultipartAsync(provider);
                // This illustrates how to get the file names.  
                foreach (MultipartFileData file in provider.FileData)
                {
                    // fileName = file.Headers.ContentDisposition.FileName;//获取上传文件实际的文件名  
                    request.ProductImgUrl = "http://" + Request.RequestUri.Authority + "/User/" + Path.GetFileName(file.LocalFileName);// file.LocalFileName.Split('\\')[3];

                    //Trace.WriteLine("Server file path: " + file.LocalFileName);//获取上传文件在服务上默认的文件名  
                }
                request.Introduce = provider.FormData["Introduce"];
                request.ProductName = provider.FormData["ProductName"];
                request.ProductTypeName = provider.FormData["ProductTypeName"];
                request.Token = provider.FormData["Token"];
                return AddProduct(request);
            }
            catch(Exception ex)
            {
                return Ok(new ResponseMsg() { IsSuccess = false,Msg= ex.Message});
            }
        }
    }
}
