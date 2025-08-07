using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using PetHomeBLL;

namespace PetHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderTypeController : ControllerBase
    {
        OrderTypeService orderTypeService = new OrderTypeService();
        /// <summary>
        /// 查询订单状态
        /// </summary>
        [HttpGet]
        public IActionResult GetOrderType()
        {
            Response_DTO<List<OrderType>> res = orderTypeService.GetOrderType();
            return new JsonResult(new
            {
                stu = res.StatuCode,
                user = res.Conten
            });
        }
        /// <summary>
        /// 添加订单状态
        /// </summary>
        [HttpPost]
        public IActionResult AddOrderType(string? SType)
        {
            Response_DTO<string> res = orderTypeService.AddOrderType(SType);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
        /// <summary>
        /// 修改订单状态
        /// </summary>
        [HttpPost]
        public IActionResult UpdataOrderType(int? Sid, string? SType)
        {
            Response_DTO<string> res = orderTypeService.UpdataOrderType(Sid, SType);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
        /// <summary>
        /// 删除订单状态
        /// </summary>
        [HttpDelete]
        public IActionResult UpdataOrderType(int? Sid)
        {
            Response_DTO<string> res = orderTypeService.DeleteOrderType(Sid);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
    }
}
