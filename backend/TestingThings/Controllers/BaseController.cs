using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestingThings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase,IActionFilter, IResultFilter, IExceptionFilter
    {
        protected readonly ILogger logger;
        protected BaseController(ILoggerFactory loggerFactory) 
        {
            logger = loggerFactory.CreateLogger<BaseController>();
        }
        [NonAction]
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("OnActionExecuted", context.ActionDescriptor);
        }
        [NonAction]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("OnActionExecuting", context.ActionArguments);
        }
        [NonAction]
        public void OnException(ExceptionContext context)
        {
            logger.LogInformation("OnResultExecuted", context.Exception);
        }
        [NonAction]
        public void OnResultExecuted(ResultExecutedContext context)
        {
            logger.LogInformation("OnResultExecuted", context.Result);
        }
        [NonAction]
        public void OnResultExecuting(ResultExecutingContext context)
        {
            logger.LogInformation("OnResultExecuting", context.Result);
        }
    }
}
