namespace BaleBotNet.Types;

public class InlineKeyboardMarkup : IReplyMarkup
{
    public InlineKeyboardButton[][] InlineKeyboard { get; set; } = default!;

    public override string ToString() => Shared.SerializeToJson(this)!;
}
