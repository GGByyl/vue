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
    /// 预约表逻辑层
    /// </summary>
    public class AppointService
    {
        AppointDAL appointDAL = new AppointDAL();
        /// <summary>
        /// 查询
        /// </summary>
        public Response_DTO<List<Appoint_DTO>> GetAppoint(AppointGet_DTO model, out int TotalCount)
        {
            Response_DTO<List<Appoint_DTO>> res = new Response_DTO<List<Appoint_DTO>>();
            //调用方法
            List<Appoint_DTO> list = appointDAL.GetAppoint(model, out TotalCount);
            res.Message = "Ok";
            res.StatuCode = 200;
            res.Conten = list;
            return res;
        }
        /// <summary>
        /// 添加
        /// </summary>
        public Response_DTO<string> AddAppoint(AppointAdd_DTO model)
        {
            Response_DTO<string> res = new Response_DTO<string>();

            #region 校验
            if (model.Auid <=0 ||model.Auid == null)
            {
                res.StatuCode = 405;
                res.Message = "请输入预约用户ID";
                return res;
            }
            if (model.Astate <= 0 || model.Astate == null)
            {
                res.StatuCode = 405;
                res.Message = "请输入预约状态";
                return res;
            }
            if (model.Amid <= 0 || model.Amid == null)
            {
                res.StatuCode = 405;
                res.Message = "请输入负责人";
                return res;
            }
            if (model.Atime == null)
            {
                res.StatuCode = 405;
                res.Message = "请输入预约时间";
                return res;
            }
            if (model.Atype <= 0 || model.Atype == null)
            {
                res.StatuCode = 405;
                res.Message = "请输入预约服务类型";
                return res;
            }
            #endregion
            bool tf = appointDAL.AddAppoint(model);
            if (tf)
            {
                res.StatuCode = 200;
                res.Message = "添加成功";
                return res;
            }
            else
            {
                res.StatuCode = 200;
                res.Message = "添加失败，请联系工作人员";
                return res;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        public Response_DTO<string> UpdataAppoint(int aid, int astate)
        {
            Response_DTO<string> res = new Response_DTO<string>();
            if (aid <= 0)
            {
                res.StatuCode = 405;
                res.Message = "请输入预约编号";
                return res;
            }
            if (astate <= 0)
            {
                res.StatuCode = 405;
                res.Message = "请输入预约状态";
                return res;
            }
            int sum = appointDAL.UpdataAppoint(aid, astate);
            if (sum  == 200)
            {
                res.StatuCode = sum;
                res.Message = "修改成功";
                return res;
            }
            else if(sum ==  405)
            {
                res.StatuCode = sum;
                res.Message = "修改失败，请联系工作人员";
                return res;
            }
            else if(sum == 506)
            {
                res.StatuCode = 405;
                res.Message = "不存在该预约状态";
                return res;
            }
            else
            {
                res.StatuCode = 405;
                res.Message = "不存在该条数据";
                return res;
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        public Response_DTO<string> DeleteAppoint(int aid)
        {
            Response_DTO<string> res = new Response_DTO<string>();
            if (aid <= 0)
            {
                res.StatuCode = 405;
                res.Message = "请输入预约编号";
                return res;
            }
            int sum = appointDAL.DeleteAppoint(aid);
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
