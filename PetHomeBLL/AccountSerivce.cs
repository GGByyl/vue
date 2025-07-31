using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DTO;
using Models.Models;
using PetHomeDAL;

namespace PetHomeBLL
{
    public class AccountSerivce
    {
        AccountDAL accountDAL = new AccountDAL();

        /// <summary>
        /// 登录
        /// </summary>
        public Response_DTO<Account> GetAccountLogin(Login_DTO model)
        {
            Response_DTO<Account> res = new Response_DTO<Account>();

            if (string.IsNullOrEmpty(model.Number))
            {
                res.StatuCode = 405;
                res.Message = "请输入账号";
                res.Success = false;
                return res;

            }

            if (string.IsNullOrEmpty(model.Password))
            {
                res.StatuCode = 405;
                res.Message = "请输入密码";
                res.Success = false;
                return res;

            }


            Account resd = accountDAL.GetAccountLogin(model);

            if (resd != null)
            {
                if (resd.Password == model.Password)
                {
                    res.StatuCode = 200;
                    res.Message = "登录成功";
                    res.Success = true;
                    res.Conten = resd;
                    return res;

                }
                else
                {
                    res.StatuCode = 405;
                    res.Message = "密码错误";
                    res.Success = false;

                    return res;


                }



            }
            else
            {
                res.StatuCode = 405;
                res.Message = "不存在该账号";
                res.Success = false;
                return res;

            }












        }

        /// <summary>
        /// 注册
        /// </summary>
        public Response_DTO<Account> Add_Account(AddAccount_DTO model)
        {
            Response_DTO<Account> res = new Response_DTO<Account>();

            #region 校验
            if (string.IsNullOrEmpty(model.Number))
            {
                res.StatuCode = 405;
                res.Message = "请输入账号";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                res.StatuCode = 405;
                res.Message = "请输入密码";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Nickname))
            {
                res.StatuCode = 405;
                res.Message = "请输入昵称";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                res.StatuCode = 405;
                res.Message = "请输入真实姓名";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                res.StatuCode = 405;
                res.Message = "请输入电话";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.Location))
            {
                res.StatuCode = 405;
                res.Message = "请输入地址";
                res.Success = false;
                return res;
            }
            if (string.IsNullOrEmpty(model.IdNumber))
            {
                res.StatuCode = 405;
                res.Message = "请输入身份证号";
                res.Success = false;
                return res;
            }
            #endregion

            bool tf = accountDAL.Add_Account(model);
            if (tf)
            {
                res.StatuCode = 200;
                res.Message = "注册成功";
                res.Success = true;
                return res;
            }
            else
            {
                res.StatuCode = 405;
                res.Message = "注册失败，请联系工作人员";
                res.Success = true;
                return res;
            }
        }

        /// <summary>
        /// 获取用户表
        /// </summary>
        public Response_DTO<List<Account>> GetAcc(Account_DTO model, out int TotalCount)
        {
            //调用方法
            List<Account> list = accountDAL.GetAcc(model, out TotalCount);
            //实例化响应模型
            Response_DTO<List<Account>> res = new Response_DTO<List<Account>>();
            res.Conten = list;
            res.Message = "Ok";
            res.StatuCode = 200;
            return res;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        public Response_DTO<string> AccountModify(ModifyAccount_DTO model)
        {
            Response_DTO<string> res = new Response_DTO<string>();

            if (string.IsNullOrEmpty(model.Number))
            {
                res.Success = false;
                res.Message = "用户名不能为空";
                res.Conten = "NO";
                return res;
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                res.Success = false;
                res.Message = "密码不能为空";
                res.Conten = "NO";
                return res;
            }

            if (string.IsNullOrEmpty(model.Nickname))
            {
                res.Success = false;
                res.Message = "昵称不能为空";
                res.Conten = "NO";
                return res;
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                res.Success = false;
                res.Message = "真实姓名不能为空";
                res.Conten = "NO";
                return res;
            }

            if (model.Sex != 0 & model.Sex != 1)
            {
                res.Success = false;
                res.Message = "性别不能为空";
                res.Conten = "NO";
                return res;
            }

            if (string.IsNullOrEmpty(model.Phone))
            {
                res.Success = false;
                res.Message = "电话号码不能为空";
                res.Conten = "NO";
                return res;
            }

            if (string.IsNullOrEmpty(model.Location))
            {
                res.Success = false;
                res.Message = "地址不能为空";
                res.Conten = "NO";
                return res;
            }

            if (string.IsNullOrEmpty(model.IdNumber))
            {
                res.Success = false;
                res.Message = "身份证号不能为空";
                res.Conten = "NO";
                return res;
            }

            if (model.Admins != 0 & model.Admins != 1)
            {
                res.Success = false;
                res.Message = "请确定是否为管理员";
                res.Conten = "NO";
                return res;
            }

            int count = accountDAL.AccountModify(model);

            if (count == 200)
            {
                res.Message = "修改成功";
                res.Conten = "OK";
                return res;

            }
            else if (count == 404)
            {
                res.Message = "没有该学生信息";
                res.Conten = "NO";
                return res;

            }
            else
            {
                res.Message = "修改失败";
                res.Conten = "NO";
                return res;

            }






        }


        /// <summary>
        /// 删除用户
        /// </summary>
        public Response_DTO<string> AccountDelete(int Aid)
        {

            Response_DTO<string> res = new Response_DTO<string>();



            int count = accountDAL.AccountDelete(Aid); 

            if (count == 200)
            {
                res.Message = "删除成工";
                res.Conten = "OK";
                return res;

            }
            else if (count == 404)
            {
                res.Message = "没有该学生信息";
                res.Conten = "NO";
                return res;

            }
            else
            {
                res.Message = "删除失败";
                res.Conten = "NO";
                return res;

            }




        }


    }
}
