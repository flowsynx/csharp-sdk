namespace FlowSynx.Client.Requests;

public class Filter
{
    public LogicOperator? Logic { get; set; } = LogicOperator.And;
    public ComparisonOperator? Comparison { get; set; } = ComparisonOperator.Equals;
    public required string Name { get; set; }
    public string? Value { get; set; }
    public string? ValueMax { get; set; }
    public List<Filter>? Filters { get; set; } = new List<Filter>();
}