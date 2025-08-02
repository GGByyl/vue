using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using PetHomeBLL;

namespace PetHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommodityController : ControllerBase
    {
        CommodityService commodityService = new CommodityService();//逻辑层
        /// <summary>
        /// 添加商品信息
        /// </summary>
        [HttpPost]
        public IActionResult AddCommdity(CommodityAdd_DTO model)
        {
            Response_DTO<Commodity> res = commodityService.AddCommdity(model);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
            
        }
        /// <summary>
        /// 修改商品信息
        /// </summary>
        [HttpPost]
        public IActionResult UpdataCommdity( CommodityUpdata_DTO model)
        {
            Response_DTO<Commodity> res = commodityService.UpdataCommdity(model);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
        /// <summary>
        /// 删除商品信息
        /// </summary>
        [HttpDelete]
        public IActionResult DeleteCommodity(int cid)
        {

            Response_DTO<string> res = commodityService.DeleteCommodity(cid);
            return new JsonResult(new
            {
                stu = res.StatuCode,
                msg = res.Message
            });
        }
    }
}
