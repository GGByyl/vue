using Microsoft.IdentityModel.Tokens;
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
    /// 商品表逻辑层
    /// </summary>
    public class CommodityService
    {
        CommodityDAL commodityDAL = new CommodityDAL();//访问层
        /// <summary>
        /// 添加商品信息
        /// </summary>
        public Response_DTO<Commodity> AddCommdity(CommodityAdd_DTO model)
        {
            Response_DTO<Commodity> res = new Response_DTO<Commodity>();

            #region 校验
            if (string.IsNullOrEmpty(model.Cname))
            {
                res.StatuCode = 405;
                res.Message = "请输入商品名称";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Price.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入商品价格";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Inventory.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入商品库存";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.ManufactureTiem.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入生产日期";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Yieldly))
            {
                res.StatuCode = 405;
                res.Message = "请输入生产地";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Expiration.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入保质期";
                res.Success = false;
                return res;
            }

            #endregion

            //
            bool tf = commodityDAL.AddCommdity(model);
            if (tf)
            {
                res.StatuCode = 200;
                res.Message = "商品添加成功";
                return res;
            }
            else
            {
                res.StatuCode = 405;
                res.Message = "商品添加失败，请联系工作人员";
                return res;
            }
        }
        /// <summary>
        /// 修改商品信息
        /// </summary>
        public Response_DTO<Commodity> UpdataCommdity(CommodityUpdata_DTO model)
        {
            Response_DTO<Commodity> res = new Response_DTO<Commodity>();

            #region 校验
            if (string.IsNullOrEmpty(model.Cname))
            {
                res.StatuCode = 405;
                res.Message = "请输入商品名称";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Price.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入商品价格";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Inventory.ToString()))
            {
                res.StatuCode = 405;
                res.Message = "请输入商品库存";
                res.Success = false;
                return res;
            }
            #endregion
            //
            bool tf = commodityDAL.UpdataCommdity(model);
            if (tf)
            {
                res.StatuCode = 200;
                res.Message = "商品修改成功";
                return res;
            }
            else
            {
                res.StatuCode = 405;
                res.Message = "商品修改失败，请联系工作人员";
                return res;
            }
        }
        /// <summary>
        /// 删除商品信息
        /// </summary>
        public Response_DTO<string> DeleteCommodity(int cid)
        {
            Response_DTO<string> res = new Response_DTO<string>();
            int sum = commodityDAL.DeleteCommodity(cid);
            if (sum == 200)
            {
                res.StatuCode = sum;
                res.Message = "删除成功";
                return res;
            }
            else if(sum == 405)
            {
                res.StatuCode = sum;
                res.Message = "删除失败，请联系工作人员";
                return res;
            }
            else
            {
                res.StatuCode = sum;
                res.Message = "不存在该条数据，删除失败，请联系工作人员";
                return res;
            }
        }
    }
}
