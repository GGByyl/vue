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
    /// 订单状态表逻辑层
    /// </summary>
    public class OrderTypeService
    {
        OrderTypeDAL orderTypeDAL = new OrderTypeDAL();
        /// <summary>
        /// 查询
        /// </summary>
        public Response_DTO<List<OrderType>> GetOrderType()
        {
            Response_DTO<List<OrderType>> res = new Response_DTO<List<OrderType>>();
            List<OrderType> list = orderTypeDAL.GetOrderType();
            res.StatuCode = 200;
            res.Conten = list;
            return res;
        }
        /// <summary>
        /// 添加
        /// </summary>
        public Response_DTO<string> AddOrderType(string SType)
        {
            Response_DTO<string> res = new Response_DTO<string>();
            if (string.IsNullOrEmpty(SType))
            {
                res.StatuCode = 405;
                res.Message = "请输入订单状态类型";
                return res;
            }
            bool tf = orderTypeDAL.AddOrderType(SType);
            if (tf)
            {
                res.StatuCode = 200;
                res.Message = "添加成功";
                return res;
            }
            else
            {
                res.StatuCode = 405;
                res.Message = "添加失败，请联系工作人员";
                return res;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public Response_DTO<string> UpdataOrderType(int? Sid, string SType)
        {
            Response_DTO<string> res = new Response_DTO<string>();
            if (Sid<=0 || Sid ==null)
            {
                res.StatuCode = 405;
                res.Message = "请输入订单状态编号";
                return res;
            }
            if (string.IsNullOrEmpty(SType))
            {
                res.StatuCode = 405;
                res.Message = "请输入订单状态类型";
                return res;
            }
            int sum = orderTypeDAL.UpdataOrderType(Sid, SType);
            if (sum == 200)
            {
                res.StatuCode = sum;
                res.Message = "修改成功";
                return res;
            }
            else if(sum == 405)
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
        /// 删除
        /// </summary>
        public Response_DTO<string> DeleteOrderType(int? Sid)
        {
            Response_DTO<string> res = new Response_DTO<string>();
            if (Sid<=0 || Sid == null)
            {
                res.StatuCode = 405;
                res.Message = "请输入订单状态编号";
                return res;
            }
            int sum = orderTypeDAL.DeleteOrderType(Sid);
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
