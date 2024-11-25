using BuberDinner.Api.Controllers;
using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Errors.ExceptionFlowControl;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers;


public class ErrorsController : ApiController
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        Console.WriteLine($"hlongcustom: {exception?.Message}");
        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        };
        return Problem(statusCode: statusCode, title: message);
    }
}