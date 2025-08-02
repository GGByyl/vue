using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    /// <summary>
    /// 添加
    /// </summary>
    public class CommodityAdd_DTO
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string? Cname { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品库存
        /// </summary>
        public int Inventory { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string? Describe { get; set; }
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime ManufactureTiem { get; set; }
        /// <summary>
        /// 生产地
        /// </summary>
        public string? Yieldly { get; set; }
        /// <summary>
        /// 保质期（单位：月）
        /// </summary>
        public int Expiration { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public int SalesVolume { get; set; }
        /// <summary>
        /// 上架日期
        /// </summary>
        public DateTime? DateIssued { get; set; }
    }
}
