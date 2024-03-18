using System.Net;

namespace BuberDinner.Application.Common.Errors.ExceptionFlowControl;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exists.";
}