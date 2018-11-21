using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SampleArchitecture.Application.Infrastructure
{
    public class DurationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public DurationBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }
        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType().Name;
            
            _logger.LogInformation($"Duration - Request: {requestName}");

            var stopwatch = Stopwatch.StartNew();
            
            var response = await next();
            
            _logger.LogInformation($"Duration - Response: {requestName} - Execution duration: {stopwatch.Elapsed}");

            return response;
        }
    }
}