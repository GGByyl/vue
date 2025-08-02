using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    /// <summary>
    /// 订单添加工具类
    /// </summary>
    public class OrderAdd_DTO
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int OrderUserId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int OrderGoodsId { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string OrderSite { get; set; } = null!;
        /// <summary>
        /// 订单状态
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public int Principal { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal? TotalPrices { get; set; }
        /// <summary>
        /// 件数
        /// </summary>
        public int? Quantity { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }
    }
}
