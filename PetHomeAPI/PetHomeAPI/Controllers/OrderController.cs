using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using PetHomeBLL;

namespace PetHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService orderService = new OrderService();//订单逻辑层
        /// <summary>
        /// 添加订单信息
        /// </summary>
        [HttpPost]
        public IActionResult AddOrder(OrderAdd_DTO model)
        {
            Response_DTO<string> res = orderService.AddOrder(model);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
        /// <summary>
        /// 修改订单信息
        /// </summary>
        [HttpPost]
        public IActionResult UpdataOrder(OrderUpdata_DTO model)
        {
            Response_DTO<string> res = orderService.UpdataOrder(model);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
        /// <summary>
        /// 删除订单信息
        /// </summary>
        [HttpDelete]
        public IActionResult DeleteOrder(string orderNumber)
        {
            Response_DTO<string> res = orderService.DeleteOrder(orderNumber);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
    }
}
