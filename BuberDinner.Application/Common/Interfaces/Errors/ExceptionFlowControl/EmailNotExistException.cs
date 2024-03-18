using System.Net;

namespace BuberDinner.Application.Common.Errors.ExceptionFlowControl;


public class EmailNotExistException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "User with given email does not exist.";
}