using FlowSynx.Client.Messages.Requests;
using System.Net.Mime;

namespace FlowSynx.Client.UnitTests.Requests;

public class RequestTests
{
    [Fact]
    public void Request_Should_Use_Default_Values()
    {
        var request = new Request
        {
            HttpMethod = HttpMethod.Get,
            Uri = "https://tests.flowsynx.io"
        };

        Assert.Equal(HttpMethod.Get, request.HttpMethod);
        Assert.Equal("https://tests.flowsynx.io", request.Uri);
        Assert.NotNull(request.Headers);
        Assert.Empty(request.Headers);
        Assert.Equal(MediaTypeNames.Application.Json, request.MediaType);
    }

    [Fact]
    public void Request_Should_Allow_Property_Setting()
    {
        var headers = new Dictionary<string, string>
        {
            { "Authorization", "Bearer xyz" }
        };

        var request = new Request
        {
            HttpMethod = HttpMethod.Post,
            Uri = "https://tests.flowsynx.io/data",
            Headers = headers,
            MediaType = MediaTypeNames.Application.Xml
        };

        Assert.Equal(HttpMethod.Post, request.HttpMethod);
        Assert.Equal("https://tests.flowsynx.io/data", request.Uri);
        Assert.Equal(headers, request.Headers);
        Assert.Equal(MediaTypeNames.Application.Xml, request.MediaType);
    }

    [Fact]
    public void GenericRequest_Should_Contain_Content()
    {
        var content = new { Id = 1, Name = "Test" };

        var request = new Request<object>
        {
            HttpMethod = HttpMethod.Get,
            Uri = "https://tests.flowsynx.io/data",
            Content = content
        };

        Assert.Equal(HttpMethod.Get, request.HttpMethod);
        Assert.Equal("https://tests.flowsynx.io/data", request.Uri);
        Assert.Equal(content, request.Content);
    }

    [Fact]
    public void GenericRequest_Should_Allow_Null_Content()
    {
        var request = new Request<string>
        {
            HttpMethod = HttpMethod.Get,
            Uri = "https://tests.flowsynx.io",
            Content = null
        };

        Assert.Null(request.Content);
    }
}