using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;
            var ex = context.Exception;

            var problem = new ProblemDetails
            {
                Title = "System error while processing error.",
                Status = (int)code
            };

            context.Result = new ObjectResult(problem);

            context.ExceptionHandled = true;
        }
    }
}