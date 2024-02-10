using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Water.API.Exceptions;

namespace Water.API.Filters;

public class UserNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is UserNotFoundException)
        {
            context.Result = new NotFoundResult();
        }
    }
}