namespace Eskitech.Contracts.Pagination
{
    public class PagedResultDto<TDto>(IEnumerable<TDto> data, int totalCount, int page, int pageSize)
        where TDto : class
    {
        public int TotalCount { get; set; } = totalCount;

        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public int Page { get; set; } = page;

        public int PageSize { get; set; } = pageSize;

        public IEnumerable<TDto> Data { get; private set; } = data;
    }
}