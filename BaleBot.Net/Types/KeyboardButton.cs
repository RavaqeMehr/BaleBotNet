namespace BaleBot.Net.Types;

public class KeyboardButton
{
    public string Text { get; set; } = default!;
    public bool? RequestContact { get; set; }
    public bool? RequestLocation { get; set; }
    public WebAppInfo? WebApp { get; set; }
}
