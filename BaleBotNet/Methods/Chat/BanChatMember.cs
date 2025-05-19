using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> BanChatMember(
        this BaleBotClient bot,
        ChatId chatId,
        long userId
    ) =>
        await bot.SendRequest<bool>(BotRequest.CreatePost("banChatMember", new { chatId, userId }));
}
