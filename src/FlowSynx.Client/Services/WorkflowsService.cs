using FlowSynx.Client.Http;
using FlowSynx.Client.Messages.Responses;
using FlowSynx.Client.Messages.Requests;
using FlowSynx.Client.Messages.Requests.Workflows;
using FlowSynx.Client.Messages.Responses.Workflows;
using FlowSynx.Client.Helpers;

namespace FlowSynx.Client.Services;

public class WorkflowsService: IWorkflowsService
{
    private readonly IHttpRequestHandler _httpRequestHandler;

    public WorkflowsService(IHttpRequestHandler httpRequestHandler) =>
        _httpRequestHandler = httpRequestHandler;

    public async Task<HttpResult<PaginatedResult<WorkflowListResponse>>> ListAsync(
        WorkflowListRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryString = QueryHelper.BuildPaginationQuery(request);

        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows{queryString}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<PaginatedResult<WorkflowListResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<AddWorkflowResponse>>> AddAsync(
        AddWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<string>
        {
            HttpMethod = HttpMethod.Post,
            Uri = "workflows",
            Content = request.Definition
        };

        return await _httpRequestHandler
            .SendRequestAsync<string, Result<AddWorkflowResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<WorkflowDetailsResponse>>> DetailsAsync(
        WorkflowDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.Id.ToString()}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<WorkflowDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> UpdateAsync(
        UpdateWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<string>
        {
            HttpMethod = HttpMethod.Put,
            Uri = $"workflows/{request.Id.ToString()}",
            Content = request.Definition
        };

        return await _httpRequestHandler
            .SendRequestAsync<string, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> DeleteAsync(
        DeleteWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Delete,
            Uri = $"workflows/{request.Id.ToString()}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<PaginatedResult<WorkflowExecutionListResponse>>> ExecutionsAsync(
        WorkflowExecutionListRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryString = QueryHelper.BuildPaginationQuery(request);

        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.WorkflowId.ToString()}/executions{queryString}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<PaginatedResult<WorkflowExecutionListResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<ExecuteWorkflowResponse>>> ExecuteAsync(
        ExecuteWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"workflows/{request.WorkflowId.ToString()}/executions"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<ExecuteWorkflowResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<WorkflowExecutionDetailsResponse>>> ExecutionsDetailsAsync(
        WorkflowExecutionDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"executions/{request.WorkflowExecutionId.ToString()}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<WorkflowExecutionDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> CancelExecutionsAsync(
        CancelWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"executions/{request.WorkflowExecutionId.ToString()}/cancel"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<PaginatedResult<WorkflowExecutionPendingApprovalsResponse>>> ExecutionPendingApprovalsAsync(
        WorkflowExecutionPendingApprovalsRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryString = QueryHelper.BuildPaginationQuery(request);

        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"executions/{request.WorkflowExecutionId.ToString()}/approvals{queryString}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<PaginatedResult<WorkflowExecutionPendingApprovalsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> ApproveExecutionsAsync(
        ApproveWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"executions/{request.WorkflowExecutionId.ToString()}/" +
            $"approvals/{request.WorkflowExecutionApprovalId.ToString()}/approve"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> RejectExecutionsAsync(
        RejectWorkflowRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
                  $"executions/{request.WorkflowExecutionId.ToString()}/" +
                  $"approvals/{request.WorkflowExecutionApprovalId.ToString()}/reject"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<Unit>>(requestMessage, cancellationToken);
    }
    public async Task<HttpResult<Result<WorkflowExecutionLogsResponse>>> ExecutionsLogsAsync(
        WorkflowExecutionLogsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"executions/{request.WorkflowExecutionId.ToString()}/logs"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<WorkflowExecutionLogsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<PaginatedResult<WorkflowExecutionTasksResponse>>> ExecutionTasksAsync(
        WorkflowExecutionTasksRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryString = QueryHelper.BuildPaginationQuery(request);

        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
                  $"executions/{request.WorkflowExecutionId.ToString()}/tasks{queryString}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<PaginatedResult<WorkflowExecutionTasksResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<WorkflowTaskExecutionDetailsResponse>>> TaskExecutionDetailsAsync(
        WorkflowTaskExecutionDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"executions/{request.WorkflowExecutionId.ToString()}/" +
            $"tasks/{request.WorkflowTaskExecutionId.ToString()}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<WorkflowTaskExecutionDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<PaginatedResult<WorkflowTaskExecutionLogsResponse>>> TaskExecutionLogsAsync(
        WorkflowTaskExecutionLogsRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryString = QueryHelper.BuildPaginationQuery(request);

        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"executions/{request.WorkflowExecutionId.ToString()}/" +
            $"tasks/{request.WorkflowTaskExecutionId.ToString()}/" +
            $"logs{queryString}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<PaginatedResult<WorkflowTaskExecutionLogsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<PaginatedResult<WorkflowTriggersListResponse>>> TriggersAsync(
        WorkflowTriggersListRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryString = QueryHelper.BuildPaginationQuery(request);

        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.WorkflowId.ToString()}/triggers{queryString}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<PaginatedResult<WorkflowTriggersListResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<AddWorkflowTriggerResponse>>> AddTriggerAsync(
        AddWorkflowTriggerRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<AddWorkflowTriggerRequest>
        {
            HttpMethod = HttpMethod.Post,
            Uri = $"workflows/{request.WorkflowId.ToString()}/triggers",
            Content = request
        };

        return await _httpRequestHandler
            .SendRequestAsync<AddWorkflowTriggerRequest, Result<AddWorkflowTriggerResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<WorkflowTriggerDetailsResponse>>> TriggerDetailsAsync(
        WorkflowTriggerDetailsRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"triggers/{request.TriggerId}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<WorkflowTriggerDetailsResponse>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> UpdateTriggerAsync(
        UpdateWorkflowTriggerRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request<UpdateWorkflowTriggerRequest>
        {
            HttpMethod = HttpMethod.Put,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"triggers/{request.TriggerId}",
            Content = request
        };

        return await _httpRequestHandler
            .SendRequestAsync<UpdateWorkflowTriggerRequest, Result<Unit>>(requestMessage, cancellationToken);
    }

    public async Task<HttpResult<Result<Unit>>> DeleteTriggerAsync(
        DeleteWorkflowTriggerRequest request,
        CancellationToken cancellationToken = default)
    {
        var requestMessage = new Request
        {
            HttpMethod = HttpMethod.Delete,
            Uri = $"workflows/{request.WorkflowId.ToString()}/" +
            $"triggers/{request.TriggerId}"
        };

        return await _httpRequestHandler
            .SendRequestAsync<Result<Unit>>(requestMessage, cancellationToken);
    }
}