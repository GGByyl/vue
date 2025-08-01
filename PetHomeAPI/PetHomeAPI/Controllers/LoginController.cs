using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using PetHomeBLL;

namespace PetHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        AccountService accountserivce = new AccountService();//登录逻辑层
        /// <summary>
        /// 登录
        /// </summary>
        [HttpPost]
        public IActionResult Login(Login_DTO model)
        {
            Response_DTO<Account> res = accountserivce.GetAccountLogin(model);

            return new JsonResult(new
            {
                mode = res.StatuCode,
                msg = res.Message,
                user = res.Conten,


            });

        }
        /// <summary>
        /// 注册
        /// </summary>
        [HttpPost]
        public IActionResult Add_Account([FromBody] AddAccount_DTO model)
        {
            Response_DTO<Account> res = accountserivce.Add_Account(model);

            return new JsonResult(new
            {
                mode = res.StatuCode,
                msg = res.Message,


            });
        }
    }
}
