using System.Net;

namespace BuberDinner.Application.Common.Interfaces.Errors.OneOfFlowControl;
    public record struct DuplicateEmailError() : IError
    {
      public string ErrorMessage { get; set; } = "Email already exists.";
      public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.BadRequest;
    }
  
