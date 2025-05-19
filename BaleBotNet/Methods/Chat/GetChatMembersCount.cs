using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<int> GetChatMembersCount(this BaleBotClient bot, ChatId chatId) =>
        await bot.SendRequest<int>(BotRequest.CreatePost("getChatMembersCount", new { chatId }));
}
