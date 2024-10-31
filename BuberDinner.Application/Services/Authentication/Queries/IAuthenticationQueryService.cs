using BuberDinner.Application.Common.Interfaces.Errors.OneOfFlowControl;
using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;
using OneOf;

namespace BuberDinner.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}