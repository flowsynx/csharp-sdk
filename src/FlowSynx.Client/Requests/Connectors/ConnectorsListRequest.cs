﻿namespace FlowSynx.Client.Requests.Connectors;

public class ConnectorsListRequest
{
    public string[]? Fields { get; set; }
    public string? Filter { get; set; }
    public bool? CaseSensitive { get; set; } = false;
    public string? Sort { get; set; }
    public string? Limit { get; set; }
}