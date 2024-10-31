using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Common.Interfaces.Errors.OneOfFlowControl;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using Microsoft.VisualBasic;
using OneOf;


namespace BuberDinner.Application.Services.Authentication.Queries;
public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationQueryService(IJwtTokenGenerator  jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // 1.validate user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2.validate password is valid
        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 3.create token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, "firstName", "lastName");
        return new AuthenticationResult(user, token);
    }

}