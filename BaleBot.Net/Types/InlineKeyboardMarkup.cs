namespace BaleBot.Net.Types;

public class InlineKeyboardMarkup : IReplyMarkup
{
    public InlineKeyboardButton[][] InlineKeyboard { get; set; } = default!;

    public string? Serialize() => BaleBotClient.SerializeToJson(this);
}
