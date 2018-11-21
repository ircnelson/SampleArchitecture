using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SampleArchitecture.Application.Infrastructure.Pagination
{
    public static class Paginate
    {
        public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, PaginationParameters query)
            => await collection.PaginateAsync(query.Page, query.Results);
        
        public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection,
            int page = 1, int resultsPerPage = 10)
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (resultsPerPage <= 0)
            {
                resultsPerPage = 10;
            }
            var isEmpty = await collection.AnyAsync() == false;
            
            if (isEmpty)
            {
                return PagedResult<T>.Empty;
            }
            
            var totalResults = await collection.CountAsync();
            
            var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);
            
            var data = await collection.Skip((page - 1) * resultsPerPage).Take(resultsPerPage).ToListAsync();

            return PagedResult<T>.Create(data, page, resultsPerPage, totalPages, totalResults);
        }
    }
}