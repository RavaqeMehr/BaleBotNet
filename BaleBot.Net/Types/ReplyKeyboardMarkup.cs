namespace BaleBot.Net.Types;

public class ReplyKeyboardMarkup : IReplyMarkup
{
    public KeyboardButton[][] Keyboard { get; set; } = default!;

    public string? Serialize() => BaleBotClient.SerializeToJson(this);
}
