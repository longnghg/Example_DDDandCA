using BuberDiner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Common.Interfaces.Errors.OneOfFlowControl;
using OneOf;
namespace RuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
// [ErrorHandlingFilter]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        OneOf<AuthenticationResult, IError> registerResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            error => Problem(statusCode: (int)error.HttpStatusCode, title: error.ErrorMessage, detail: "The 2email you provided already exists in the system")
        );
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult result)
    {
        return new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationService.Login(request.Email, request.Password);
        return Ok(new AuthenticationResponse(
           result.User.Id,
           result.User.FirstName,
           result.User.LastName,
           result.User.Email,
           result.Token));
    }

}