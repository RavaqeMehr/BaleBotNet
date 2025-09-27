namespace BaleBotNet.Safir.Types;

public class ErrorInfo
{
    public required string PhoneNumber { get; set; }
    public int Code { get; set; }
    public string Description { get; set; } = "";
}
