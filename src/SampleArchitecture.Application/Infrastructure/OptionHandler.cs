using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Optional;

namespace SampleArchitecture.Application.Infrastructure
{
    public abstract class OptionHandler<TRequest, TResponse> : IRequestHandler<TRequest, Option<TResponse>> where TRequest : IRequest<Option<TResponse>>
    {
        public abstract Task<Option<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}