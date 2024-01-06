namespace FlowSynx.Client.Exceptions;

public class FlowSynxClientException : Exception
{
    public FlowSynxClientException(string message) : base(message) { }
    public FlowSynxClientException(string message, Exception inner) : base(message, inner) { }
}