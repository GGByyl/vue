using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using PetHomeBLL;

namespace PetHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountService accountSerivce = new AccountService();
        /// <summary>
        /// 获取用户表
        /// </summary>
        [HttpGet]
        public IActionResult GetAcc([FromQuery] Account_DTO model)
        {
            int TotalCount;
            Response_DTO<List<Account>> res = accountSerivce.GetAcc(model, out TotalCount);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                user = res.Conten,
                msg = res.Message
            });
        }
        /// <summary>
        /// 注册
        /// </summary>
        [HttpPost]
        public IActionResult Add_Account([FromBody] AddAccount_DTO model)
        {
            Response_DTO<Account> res = accountSerivce.Add_Account(model);

            return new JsonResult(new
            {
                mode = res.StatuCode,
                msg = res.Message,


            });
        }


        /// <summary>
        /// 修改用户                        
        /// </summary>
        [HttpPost]
        public IActionResult AccountModify(ModifyAccount_DTO model)
        {
            Response_DTO<string> res = accountSerivce.AccountModify(model);

            return new JsonResult(new
            {
                stu = res.Conten,
                msg = res.Message
            });



        }

        /// <summary>
        /// 删除用户
        /// </summary>
        [HttpDelete]
        public IActionResult AccountDelete(int Aid)
        {
            Response_DTO<string> res = accountSerivce.AccountDelete(Aid);

            return new JsonResult(new
            {
                stu = res.Conten,
                msg = res.Message
            });

        }
    }
}
