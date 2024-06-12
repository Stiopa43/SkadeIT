using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase, IActionFilter
    {
        [NonAction]
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
        [NonAction]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!ModelState.IsValid)
            {
                SerializableError error = new BadRequestObjectResult(context.ModelState).Value as SerializableError;

                throw new CSBadRequestException(error
                    .ToDictionary(x => x.Key, x => string.Join(',', x.Value as string[])));
            }
        }
    }
}
