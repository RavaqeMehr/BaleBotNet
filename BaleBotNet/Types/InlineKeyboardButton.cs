namespace BaleBotNet.Types;

public class InlineKeyboardButton
{
    public string Text { get; set; } = default!;
    public string? Url { get; set; }
    public string? CallbackData { get; set; }
    public WebAppInfo? WebApp { get; set; }
    public CopyTextButton? CopyText { get; set; }
}
