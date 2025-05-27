namespace BaleBotNet.Types;

public class Invoice
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string StartParameter { get; set; } = default!;
    public string Currency { get; set; } = default!;
    public int TotalAmount { get; set; }
}
