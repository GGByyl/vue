using Models.DTO;
using Models.Models;
using PetHomeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHomeBLL
{
    /// <summary>
    /// 订单表逻辑层
    /// </summary>
    public class OrderService
    {
        OrderDAL orderDAL = new OrderDAL();//订单访问层
        /// <summary>
        /// 添加订单信息
        /// </summary>
        public Response_DTO<string> AddOrder(OrderAdd_DTO model)
        {
            Response_DTO<string> res = new Response_DTO<string>();

            #region 校验
            if (string.IsNullOrEmpty(model.OrderUserId.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入用户ID";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.OrderGoodsId.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入商品ID";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.OrderSite))
            {
                res.StatuCode = 405;
                res.Message = "请输入收货地址";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.OrderState.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入订单状态";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Principal.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入负责人";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.TotalPrices.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入总价";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Quantity.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入件数";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.UnitPrice.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入单价";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.OrderTime.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入下单时间";
                res.Success = false;
                return res;
            }
            #endregion
            //
            int sum = orderDAL.AddOrder(model);
            if (sum == 200)
            {
                res.StatuCode = sum;
                res.Message = "添加商品成功";
                return res;
            }
            else
            {
                res.StatuCode = sum;
                res.Message = "添加商品失败，请联系工作人员";
                return res;
            }
        }
        /// <summary>
        /// 修改订单信息
        /// </summary>
        public Response_DTO<string> UpdataOrder(OrderUpdata_DTO model)
        {
            Response_DTO<string> res = new Response_DTO<string>();
            if (string.IsNullOrEmpty(model.OrderSite))
            {
                res.StatuCode = 405;
                res.Message = "请输入收货地址";
                return res;
            }
            if (model.OrderState <=0)
            {
                res.StatuCode = 405;
                res.Message = "请输入订单状态";
                return res;
            }
            int sum = orderDAL.UpdataOrder(model);
            if (sum == 200)
            {
                res.StatuCode = sum;
                res.Message = "修改成功";
                return res;
            }
            else if (sum == 405)
            {
                res.StatuCode = sum;
                res.Message = "修改失败，请联系工作人员";
                return res;
            }
            else
            {
                res.StatuCode = sum;
                res.Message = "不存在该条数据";
                return res;
            }
        }
        /// <summary>
        /// 删除订单信息
        /// </summary>
        public Response_DTO<string> DeleteOrder(string orderNumber)
        {
            Response_DTO<string> res = new Response_DTO<string>();
            if (string.IsNullOrEmpty(orderNumber))
            {
                res.StatuCode = 405;
                res.Message = "请输入订单编号";
                return res;
            }
            int sum = orderDAL.DeleteOrder(orderNumber);
            if (sum == 200)
            {
                res.StatuCode = sum;
                res.Message = "删除成功";
                return res;
            }
            else if (sum == 405)
            {
                res.StatuCode = sum;
                res.Message = "删除失败，请联系工作人员";
                return res;
            }
            else
            {
                res.StatuCode = sum;
                res.Message = "不存在该条数据";
                return res;
            }
        }
    }
}
