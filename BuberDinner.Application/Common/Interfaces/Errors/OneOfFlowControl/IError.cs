using System.Net;

namespace BuberDinner.Application.Common.Interfaces.Errors.OneOfFlowControl;
    public interface IError
    {
      public string ErrorMessage { get; set; }
      public HttpStatusCode HttpStatusCode { get; set; }
    }
  
