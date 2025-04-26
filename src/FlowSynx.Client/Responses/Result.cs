namespace FlowSynx.Client.Responses;

public class Result : IResult
{
    public Result()
    {
    }

    public List<string> Messages { get; set; } = new List<string>();

    public bool Succeeded { get; set; }

    public DateTime GeneratedAtUtc { get; }
}

public class Result<T> : Result, IResult<T>
{
    public T Data { get; set; } = default!;
}