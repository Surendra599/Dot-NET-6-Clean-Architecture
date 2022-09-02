using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboradController : ControllerBase
    {

        [HttpGet]

        public IActionResult Index()
        {



            return Ok();
        }

    }
}
