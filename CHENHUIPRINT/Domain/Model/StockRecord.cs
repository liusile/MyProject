using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class StockRecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 仓库记录号
        /// </summary>
        public string StockRecordNo { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public string Supplier { get; set; }
        /// <summary>
        /// 库存类型
        /// </summary>
        public StockType StockType { get; set; }
        /// <summary>
        /// 仓管
        /// </summary>
        public string StorageManager { get; set; }
        /// <summary>
        /// 采购人
        /// </summary>
        public string Purchaser { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperPeople { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public List<Product> Product { get; set; }
    }

    public enum StockType
    {
        In,

        Out
    }

    public class Product
    {
        public int ProductId { get; set; }

        /// <summary>
        /// 耗材类型
        /// </summary>
        public string ProductType { get; set; }
        /// <summary>
        /// 子类型
        /// </summary>
        public string ProductSubType { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Spec { get; set; }
        /// <summary>
        /// 克数
        /// </summary>
        public decimal Grammage { get; set; }
        /// <summary>
        /// 吨价
        /// </summary>
        public decimal TonOfPrice { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
