using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Optional;
using Optional.Unsafe;
using SampleArchitecture.Application.Infrastructure.Pagination;

namespace SampleArchitecture.WebApi.Infrastructure
{
    public static class OptionalHttpResponseExtensions
    {
        public static IActionResult AsHttpResponse<T>(this Option<T> option, HttpContext context)
        {
            if (!option.HasValue) return new NotFoundResult();

            var value = option.ValueOrDefault();

            dynamic output = value;

            if (value is IPagedResult pagedResult)
            {
                var paginateMetadata = new
                {
                    pagedResult.CurrentPage,
                    pagedResult.ResultsPerPage,
                    pagedResult.TotalPages,
                    pagedResult.TotalResults
                };

                context.Response.Headers.Add("Paginate",
                    JsonConvert.SerializeObject(paginateMetadata,
                        new JsonSerializerSettings()
                            {ContractResolver = new CamelCasePropertyNamesContractResolver()}));
                
                output = (pagedResult as dynamic).Items;
            }
            
            var result = new OkObjectResult(output);
            
            return result;
        }
    }
}