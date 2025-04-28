using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<int> GetChatMembersCount(this BaleBotClient bot, ChatId chatId) =>
        await bot.SendRequest<int>(BotRequest.CreatePost("getChatMembersCount", new { chatId }));
}
