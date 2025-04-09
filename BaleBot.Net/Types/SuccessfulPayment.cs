namespace BaleBot.Net.Types;

public class SuccessfulPayment
{
    public string Currency { get; set; } = default!;
    public long TotalAmount { get; set; }
    public string InvoicePayload { get; set; } = default!;
    public string TelegramPaymentChargeId { get; set; } = default!;
    public string ProviderPaymentChargeId { get; set; } = default!;
}
