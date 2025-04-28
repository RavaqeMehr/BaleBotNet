using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> SetChatTitle(
        this BaleBotClient bot,
        ChatId chatId,
        string title
    ) => await bot.SendRequest<bool>(BotRequest.CreatePost("setChatTitle", new { chatId, title }));
}
