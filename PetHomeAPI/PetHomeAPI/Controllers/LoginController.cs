using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetHomeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public void Get()
        {

        }
    }
}
