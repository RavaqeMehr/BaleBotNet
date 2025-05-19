using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> UnBanChatMember(
        this BaleBotClient bot,
        ChatId chatId,
        long userId,
        bool onlyIfBanned
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost(
                "unbanChatMember",
                new
                {
                    chatId,
                    userId,
                    onlyIfBanned
                }
            )
        );
}
