namespace FlowSynx.Client.Responses.Version;

public class VersionResponse
{
    public string FlowSynx { get; set; } = string.Empty;
    public string? OSVersion { get; set; } = string.Empty;
    public string? OSArchitecture { get; set; } = string.Empty;
    public string? OSType { get; set; } = string.Empty;
}