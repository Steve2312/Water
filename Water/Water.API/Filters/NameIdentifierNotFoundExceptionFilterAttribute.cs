using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Water.API.Exceptions;

namespace Water.API.Filters;

public class NameIdentifierNotFoundExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is NameIdentifierNotFoundException)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}