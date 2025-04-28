using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> BanChatMember(
        this BaleBotClient bot,
        ChatId chatId,
        long userId
    ) =>
        await bot.SendRequest<bool>(BotRequest.CreatePost("banChatMember", new { chatId, userId }));
}
