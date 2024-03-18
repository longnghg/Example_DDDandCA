using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Errors;


  public class BuberDinnerProblemDetails : ProblemDetails
    {
        public string Detail { get; set; }
        public int StatusCode { get; set; }
    }