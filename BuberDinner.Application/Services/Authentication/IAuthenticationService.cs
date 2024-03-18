using BuberDinner.Application.Common.Interfaces.Errors.OneOfFlowControl;
using OneOf;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    OneOf<AuthenticationResult,IError> Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}