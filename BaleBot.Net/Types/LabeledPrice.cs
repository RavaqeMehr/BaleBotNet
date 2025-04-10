namespace BaleBot.Net.Types;

public class LabeledPrice
{
    public string Label { get; set; } = default!;
    public long Amount { get; set; }
}
