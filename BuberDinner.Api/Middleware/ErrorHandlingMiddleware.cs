// using System.Net;
// using System.Text.Json;

// namespace BuberDiner.Api.Middleware;

// public class ErrorHandlingMiddleware
// {
//     private readonly RequestDelegate _next;
//     private readonly ILogger<ErrorHandlingMiddleware> _logger;

//     public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
//     {
//         _next = next;
//         _logger = logger;
//     }

//     public async Task Invoke(HttpContext context)
//     {
//         try
//         {
//             await _next(context);
//         }
//         catch (Exception ex)
//         {
//             await HandleExceptionAsync(context, ex);
//         }
//     }

//     private async Task HandleExceptionAsync(HttpContext context, Exception ex)
//     {
//         _logger.LogError(ex, ex.Message);
//         context.Response.ContentType = "application/json";
//         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

//         var response = new { error = "Internal Server Error" };
//         var payload = JsonSerializer.Serialize(response);
//         await context.Response.WriteAsync(payload);
//     }
// }
