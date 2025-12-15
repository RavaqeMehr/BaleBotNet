using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<ChatMember> GetChatMember(
        this BaleBotClient bot,
        ChatId chatId,
        long userId
    ) =>
        await bot.SendRequest<ChatMember>(
            BotRequest.CreatePost("getChatMember", new { chatId, userId })
        );
}
