using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CostaSoftware_CleanArchitecture.Api.Filters;

[Obsolete("use ErrorOf")]
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Type = "",
            Instance = context.HttpContext.Request.Path,
            Title = "An error occurred while processing your request!",
            Status = StatusCodes.Status500InternalServerError
        };

        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
