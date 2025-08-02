using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    /// <summary>
    /// 商品表修改DTO
    /// </summary>
    public class CommodityUpdata_DTO
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Cid { get; set; }
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
        /// 上架日期
        /// </summary>
        public DateTime? DateIssued { get; set; }
    }
}
