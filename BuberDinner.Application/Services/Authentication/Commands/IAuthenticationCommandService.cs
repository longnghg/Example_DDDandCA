using BuberDinner.Application.Common.Interfaces.Errors.OneOfFlowControl;
using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;
using OneOf;

namespace BuberDinner.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}