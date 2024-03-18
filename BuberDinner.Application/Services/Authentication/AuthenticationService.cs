using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces;
using BuberDinner.Application.Common.Interfaces.Errors.OneOfFlowControl;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using Microsoft.VisualBasic;
using OneOf;


namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1.validate user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Invalid password");
        }

        // 2.validate password is valid
        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        // 3.create token
        var token = _jwtTokenGenerator.GenerateToken(user.Id, "firstName", "lastName");
        return new AuthenticationResult(user, token);
    }

    public OneOf<AuthenticationResult,IError> Register(string firstName, string lastName, string email, string password)
    {
        // 1. check if user exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return new IError();
        }

        // 2. create user
        var user = new User(firstName, lastName, email, password);

        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

        return new AuthenticationResult(
            user,
            token);
    }
}