namespace BaleBot.Net.Types;

public class InlineKeyboardMarkup : IReplyMarkup
{
    public InlineKeyboardButton[][] InlineKeyboard { get; set; } = default!;

    public override string ToString() => BaleBotClient.SerializeToJson(this)!;
}
