namespace SampleArchitecture.Application.Infrastructure.Pagination
{
    public abstract class PaginationParameters
    {
        public int Page { get; set; } = 1;
        public int Results { get; set; } = 10;
        public string OrderBy { get; set; }
        public string SortOrder { get; set; }
    }

    public static class PaginationParametersExtensions
    {
        public static int GetSkip(this PaginationParameters paginationParameters)
        {
            var page = paginationParameters.Page <= 0 ? 1 : paginationParameters.Page;
            var results = paginationParameters.Results <= 0 ? 10 : paginationParameters.Results;
            
            return (page - 1) * results;
        }
    }
}