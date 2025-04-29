namespace BaleBot.Net.Types;

public interface IReplyMarkup
{
    string ToString();
}

public static class ReplyKeyboard
{
    public static IReplyMarkup Clear() => new ClearKeyboardMarkup();

    public static IReplyMarkup CreateKeyboard(KeyboardButton[][] buttons) =>
        new ReplyKeyboardMarkup { Keyboard = buttons };

    public static IReplyMarkup CreateInline(InlineKeyboardButton[][] buttons) =>
        new InlineKeyboardMarkup { InlineKeyboard = buttons };
}
