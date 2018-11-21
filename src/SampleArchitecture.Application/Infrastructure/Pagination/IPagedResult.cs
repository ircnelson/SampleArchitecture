using System.Collections.Generic;

namespace SampleArchitecture.Application.Infrastructure.Pagination
{
    public interface IPagedResult<T> : IPagedResult
    {
        IEnumerable<T> Items { get; }
        bool IsEmpty { get; }
    }

    public interface IPagedResult
    {
        int CurrentPage { get; }
        int ResultsPerPage { get; }
        int TotalPages { get; }
        long TotalResults { get; }
    }
}