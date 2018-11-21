using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleArchitecture.Application.Handlers.Bancos.Queries;
using SampleArchitecture.WebApi.Infrastructure;

namespace SampleArchitecture.WebApi.Controllers
{
    [Route("bancos")]
    public class BancosController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ObterBancosQuery query)
        {
            var response = await Dispatcher.Send(query);

            return response.AsHttpResponse(HttpContext);
        }

        [HttpGet("{id}", Name = "GetBancoById")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await Dispatcher.Send(new ObterBancoQuery {Id = id});

            return response.AsHttpResponse(HttpContext);
        }
    }
}