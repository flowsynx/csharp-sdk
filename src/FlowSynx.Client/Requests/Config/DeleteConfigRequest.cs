namespace FlowSynx.Client.Requests.Config;

public class DeleteConfigRequest
{
    public FilterList? Filter { get; set; }
    public SortList? Sort { get; set; }
    public Paging? Paging { get; set; }
    public bool? CaseSensitive { get; set; } = false;
}