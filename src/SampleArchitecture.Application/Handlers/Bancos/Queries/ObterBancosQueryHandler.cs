using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Optional;
using SampleArchitecture.Application.Infrastructure;
using SampleArchitecture.Application.Infrastructure.Pagination;
using SampleArchitecture.Data.EFCore;

namespace SampleArchitecture.Application.Handlers.Bancos.Queries
{
    public class ObterBancosQueryHandler  : OptionHandler<ObterBancosQuery, IPagedResult<ObterBancosQueryResult>>
    {
        private readonly ExampleContext _context;

        public ObterBancosQueryHandler(ExampleContext context)
        {
            _context = context;
        }
        
        public override async Task<Option<IPagedResult<ObterBancosQueryResult>>> Handle(ObterBancosQuery request, CancellationToken cancellationToken)
        {
            return await GetUsingDapper(request).ConfigureAwait(false);
        }
        
        private async Task<Option<IPagedResult<ObterBancosQueryResult>>> GetUsingDapper(ObterBancosQuery request)
        {
            const string sql = @"
SELECT COUNT(*) FROM Bancos;

SELECT
        Id,
        Codigo,
        Nome,
        NomeCurto  

FROM Bancos
LIMIT @count OFFSET @skip;";
            
            var sqlParameters = new { skip = request.GetSkip(), count = request.Results };
            
            using (var multiResults = await _context.Database
                .GetDbConnection()
                .QueryMultipleAsync(sql, sqlParameters))
            {
                var total = await multiResults.ReadFirstOrDefaultAsync<long>();
                var records = await multiResults.ReadAsync<ObterBancosQueryResult>();

                var pagedResult =
                    PagedResult<ObterBancosQueryResult>.Create(records, request.Page, request.Results, total);

                return Option.Some<IPagedResult<ObterBancosQueryResult>>(pagedResult);
            }
        }
    }
    
    public class ObterBancosQuery : PaginationParameters, IRequest<Option<IPagedResult<ObterBancosQueryResult>>>
    {
    }

    public class ObterBancosQueryResult
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeCurto { get; set; }
    }
    
}