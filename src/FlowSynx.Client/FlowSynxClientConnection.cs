using FlowSynx.Client.Exceptions;

namespace FlowSynx.Client;

public interface IFlowSynxClientConnection
{
    string BaseAddress { get; }
}

public class FlowSynxClientConnection: IFlowSynxClientConnection
{
    public string BaseAddress { get; }

    public FlowSynxClientConnection(string baseAddress)
    {
        CheckAddress(baseAddress);
        BaseAddress = baseAddress;
    }

    private void CheckAddress(string baseAddress)
    {
        if (!IsUrlValid(baseAddress))
            throw new FlowSynxClientException(string.Format(Resources.HttpClient_EnteredAddressIsInvalid, baseAddress));
    }

    private bool IsUrlValid(string url) => Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                                       && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
}