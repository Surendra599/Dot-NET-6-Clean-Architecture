using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public IActionResult Index()
        {

            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            // return View();
            return Problem();
        }
    }
}
