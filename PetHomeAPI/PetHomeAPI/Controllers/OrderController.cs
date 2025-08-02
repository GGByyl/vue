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
    }
}
