# FlowSynx.Client SDK for C#

[![dotnet][dotnet-budge]][dotnet-url] [![License: MIT][mit-badge]][mit-url] [![Build Status][actions-badge]][actions-url] [![FOSSA Status][fossa-badge]][fossa-url]

[mit-badge]: https://img.shields.io/github/license/flowsynx/csharp-sdk?style=flat&label=License&logo=github
[mit-url]: https://github.com/flowsynx/csharp-sdk/blob/master/LICENSE
[actions-badge]: https://github.com/flowsynx/csharp-sdk/actions/workflows/sdk_build.yml/badge.svg?branch=master
[actions-url]: https://github.com/flowsynx/csharp-sdk/actions?workflow=build-nuget
[fossa-badge]: https://app.fossa.com/api/projects/git%2Bgithub.com%2Fflowsynx%2Fcsharp-sdk.svg?type=shield&issueType=license
[fossa-url]: https://app.fossa.com/projects/git%2Bgithub.com%2Fflowsynx%2Fcsharp-sdk?ref=badge_shield&issueType=license
[dotnet-budge]: https://img.shields.io/badge/.NET-9.0-blue
[dotnet-url]: https://dotnet.microsoft.com/en-us/download/dotnet/9.0

**FlowSynx.Client** is a modern, extensible C# SDK designed to integrate seamlessly with 
the [FlowSynx Workflow Automation Engine](https://flowsynx.io), providing a streamlined way to interact with its powerful REST API. 
This SDK enables developers to manage workflows, plugins, executions, configurations, and more through a simple, fluent .NET API.

## 🚀 Features
- Connect securely to FlowSynx via REST
- Manage workflows and plugin configurations
- Trigger and monitor workflow executions
- Upload and retrieve logs and metadata
- Authentication support (Basic, Bearer, and custom token handlers)
- Lightweight, dependency-free architecture
- Built for .NET 9.0 with extensibility and clean architecture in mind

## 📦 Installation
You can install the SDK via [NuGet](https://www.nuget.org/packages/FlowSynx.Client):

```
dotnet add package FlowSynx.Client
```

## 🧩 Usage
1. Configure the Client

Make sure the blow package are added to you project:
```
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Hosting
```

Then use the FlowSynx Client like following:
```
IAuthenticationStrategy authStrategy = new BasicAuthenticationStrategy("admin", "admin");

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddHttpClient();
        services.AddSingleton<IFlowSynxServiceFactory, FlowSynxServiceFactory>();
        services.AddSingleton(authStrategy);
        services.AddSingleton<IFlowSynxClient, FlowSynxClient>();
    })
    .Build();

var client = host.Services.GetRequiredService<IFlowSynxClient>();
```

2. List Available Workflows
```
var result = await _flowSynxClient.Workflows.ListAsync(cancellationToken);
var workflows = result.Payload;
foreach (var workflow in workflows)
{
    Console.WriteLine($"{workflow.Id}: {workflow.Name}");
}
```

3. Execute a Workflow
```
Guid workflowId = Guid.Parse("YOUR-WORKFLOW-ID");
var workflowRequest = new ExecuteWorkflowRequest { WorkflowId = workflowId };
var result = await _flowSynxClient.Workflows.ExecuteAsync(workflowRequest, cancellationToken);
```

## ✅ Requirements
- .NET 9.0 or later
- Compatible with Windows, Linux, macOS