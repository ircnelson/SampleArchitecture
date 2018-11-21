using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Optional;
using SampleArchitecture.Application.Infrastructure;
using SampleArchitecture.Data;
using SampleArchitecture.Data.EFCore;

namespace SampleArchitecture.Application.Handlers.Bancos.Queries
{
    public class ObterBancoQueryHandler : OptionHandler<ObterBancoQuery, ObterBancoQueryResult>
    {
        private readonly ExampleContext _context;

        public ObterBancoQueryHandler(ExampleContext context)
        {
            _context = context;
        }
        
        public override async Task<Option<ObterBancoQueryResult>> Handle(ObterBancoQuery request, CancellationToken cancellationToken)
        {
            var cidade = await GetUsingDapper(request, cancellationToken).ConfigureAwait(false);

            if (cidade == null) return Option.None<ObterBancoQueryResult>();
            
            return Option.Some(cidade);
        }

        private async Task<ObterBancoQueryResult> GetUsingDapper(ObterBancoQuery request,
            CancellationToken cancellationToken)
        {
            const string sql = @"
SELECT 
       Id,
       Codigo,
       Nome,
       NomeCurto
FROM Bancos

WHERE Id = @id";

            var records = await _context.Database
                .GetDbConnection()
                .QueryFirstOrDefaultAsync(sql, new { id = request.Id })
                .ConfigureAwait(false);

            return Mapper.Map<ObterBancoQueryResult>(records);
        }
    }
    
    public class ObterBancoQuery : IRequest<Option<ObterBancoQueryResult>>
    {
        public long Id { get; set; }
    }

    public class ObterBancoQueryResult
    {
        public long Id { get; set; }
        
        public string Codigo { get; set; }

        public string Nome { get; set; }
        
        public string NomeCurto { get; set; }
    }
}