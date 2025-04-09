namespace BaleBot.Net.Types;

public class Response<T>
{
    public bool Ok { get; set; }
    public T? Result { get; set; }
    public string? Description { get; set; }
    public long? ErrorCode { get; set; }
    public object? Parameters { get; set; } //ResponseParameters  type ??!!
}
