// using System.Net;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;

// namespace BuberDinner.Api.Filters;

//   public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
//     {

//         public override void OnException(ExceptionContext context)
//         {
//             var exception = context.Exception;
//             var problemDetail  = new ProblemDetails
//             {
//                 Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
//                 Title = "An error occurred in your request",
//                 Status = (int)HttpStatusCode.InternalServerError,
//             };

//             context.Result = new ObjectResult(problemDetail);
//             context.ExceptionHandled = true;
//         }
//     }