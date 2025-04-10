namespace BaleBot.Net.Types;

public class PreCheckoutQuery
{
    public string Id { get; set; } = default!;
    public User From { get; set; } = default!;
    public string Currency { get; set; } = default!;
    public long TotalAmount { get; set; }
    public string InvoicePayload { get; set; } = default!;
}
