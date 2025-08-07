using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using PetHomeBLL;

namespace PetHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointController : ControllerBase
    {
        AppointService appointService = new AppointService();
        /// <summary>
        /// 查询预约表
        /// </summary>
        [HttpGet]
        public IActionResult GetAppoint()//[FromQuery] AppointGet_DTO model)
        {
            //int TotalCount;
            //Response_DTO<List<Appoint_DTO>> res = appointService.GetAppoint(model, out TotalCount);
            return new JsonResult(new
            {
                V =
                /*stu = res.StatuCode,
user = res.Conten,
msg = res.Message*/
                Path.GetDirectoryName(typeof(Program).Assembly.Location)
            });
        }
        /// <summary>
        /// 添加预约
        /// </summary>
        [HttpPost]
        public IActionResult AddAppoint(AppointAdd_DTO model)
        {
            Response_DTO<string> res = appointService.AddAppoint(model);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
        /// <summary>
        /// 修改预约
        /// </summary>
        [HttpPost]
        public IActionResult UpdataAppoint(int aid, int astate)
        {
            Response_DTO<string> res = appointService.UpdataAppoint(aid, astate);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
        /// <summary>
        /// 删除预约
        /// </summary>
        [HttpDelete]
        public IActionResult DeleteAppoint(int aid)
        {
            Response_DTO<string> res = appointService.DeleteAppoint(aid);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
    }
}
