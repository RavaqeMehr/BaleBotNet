using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> UnPinAllChatMessages(this BaleBotClient bot, ChatId chatId) =>
        await bot.SendRequest<bool>(BotRequest.CreatePost("unpinAllChatMessages", new { chatId }));
}
