using CostaSoftware_CleanArchitecture.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CostaSoftware_CleanArchitecture.Api.Controllers;

public class ErrorsController : ApiController
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public IActionResult Error()
    {
        IServiceException? exception = (IServiceException?)(HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error);

        //if(exception is DuplicateEmailException duplicateEmailException)
        //{

        //}

        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)exception.StatusCode, exception.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred"),
        };
        return Problem(statusCode: statusCode, title: message);
    }
}
