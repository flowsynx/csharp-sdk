namespace FlowSynx.Client.Helpers;

internal class QueryHelper
{
    public static string BuildPaginationQuery<T>(T request)
    {
        if (request == null)
            return string.Empty;

        var type = typeof(T);
        var queryParams = new List<string>();

        var pageProp = type.GetProperty("Page");
        var pageSizeProp = type.GetProperty("PageSize");

        var pageValue = pageProp?.GetValue(request);
        var pageSizeValue = pageSizeProp?.GetValue(request);

        if (pageValue != null && int.TryParse(pageValue.ToString(), out var page) && page > 0)
            queryParams.Add($"page={page}");

        if (pageSizeValue != null && int.TryParse(pageSizeValue.ToString(), out var pageSize) && pageSize > 0)
            queryParams.Add($"pagesize={pageSize}");

        return queryParams.Any()
            ? "?" + string.Join("&", queryParams)
            : string.Empty;
    }
}
