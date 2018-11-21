using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SampleArchitecture.WebApi.Infrastructure
{
    public class CustomValidationProblemDetails<T> : ProblemDetails
    {
        public ICollection<T> Details { get; set; }
    }
}