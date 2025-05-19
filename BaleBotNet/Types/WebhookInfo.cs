namespace BaleBotNet.Types;

public class WebhookInfo
{
    public string Url { get; set; } = default!;
    public bool HasCustomCertificate { get; set; }
    public int PendingUpdateCount { get; set; }
}
