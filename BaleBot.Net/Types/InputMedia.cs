namespace BaleBot.Net.Types;

public abstract class InputMedia
{
    public string Type { get; set; } = default!;
    public string Media { get; set; } = default!;
    public string? Caption { get; set; }
}
