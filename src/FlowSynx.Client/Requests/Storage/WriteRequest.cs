﻿namespace FlowSynx.Client.Requests.Storage;

public class WriteRequest
{
    public string Path { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
}