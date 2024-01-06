namespace Client;

public abstract class Example
{
    public abstract string DisplayName { get; }
    public abstract Task RunAsync(CancellationToken cancellationToken);
}