﻿namespace FlowSynx.Client.Messages.Responses.Metrics.Query;

public class SummaryResponse
{
    public int ActiveWorkflows { get; set; }
    public int RunningTasks { get; set; }
    public int CompletedToday { get; set; }
    public int FailedWorkflows { get; set; }
}