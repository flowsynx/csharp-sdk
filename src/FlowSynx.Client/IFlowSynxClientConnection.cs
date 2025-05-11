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
