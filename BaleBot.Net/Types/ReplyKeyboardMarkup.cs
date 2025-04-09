namespace BaleBot.Net.Types;

public interface IReplyMarkup
{
    string? Serialize();
}

public class ReplyKeyboardMarkup : IReplyMarkup
{
    public KeyboardButton[][] Keyboard { get; set; } = default!;

    public string? Serialize() => BaleBotClient.SerializeToJson(this);
}
