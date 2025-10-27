namespace FlowSynx.Client.Messages.Responses;

public class PaginatedResult<T> : Result<List<T>>
{
    public PaginationInfo Pagination { get; set; } = new PaginationInfo();
}

public class PaginationInfo
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}