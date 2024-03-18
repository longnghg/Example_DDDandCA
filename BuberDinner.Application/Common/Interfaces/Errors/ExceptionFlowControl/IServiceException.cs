using System.Net;

namespace   BuberDinner.Application.Common.Errors.ExceptionFlowControl;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}