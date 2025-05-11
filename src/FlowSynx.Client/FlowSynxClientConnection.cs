using FlowSynx.Client.Exceptions;

namespace FlowSynx.Client;

/// <summary>
/// Represents a client connection to the FlowSynx service.
/// </summary>
public interface IFlowSynxClientConnection
{
    /// <summary>
    /// Gets the base address of the FlowSynx client connection.
    /// </summary>
    string BaseAddress { get; }
}

/// <summary>
/// Implementation of <see cref="IFlowSynxClientConnection"/> that manages the connection's base address and validates it.
/// </summary>
public class FlowSynxClientConnection : IFlowSynxClientConnection
{
    /// <summary>
    /// Gets the base address of the FlowSynx client connection.
    /// </summary>
    public string BaseAddress { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FlowSynxClientConnection"/> class with a specified base address.
    /// </summary>
    /// <param name="baseAddress">The base address of the FlowSynx client connection.</param>
    /// <exception cref="FlowSynxClientException">Thrown when the base address is invalid.</exception>
    public FlowSynxClientConnection(string baseAddress)
    {
        CheckAddress(baseAddress);
        BaseAddress = baseAddress;
    }

    /// <summary>
    /// Validates the specified base address and throws an exception if it is invalid.
    /// </summary>
    /// <param name="baseAddress">The base address to validate.</param>
    /// <exception cref="FlowSynxClientException">Thrown when the base address is invalid.</exception>
    private void CheckAddress(string baseAddress)
    {
        if (!IsUrlValid(baseAddress))
            throw new FlowSynxClientException(string.Format(Resources.HttpClient_EnteredAddressIsInvalid, baseAddress));
    }

    /// <summary>
    /// Determines whether the provided URL is valid and has either an HTTP or HTTPS scheme.
    /// </summary>
    /// <param name="url">The URL to validate.</param>
    /// <returns><c>true</c> if the URL is valid and uses HTTP or HTTPS; otherwise, <c>false</c>.</returns>
    private bool IsUrlValid(string url) =>
        Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
        && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
}