using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> SetChatDescription(
        this BaleBotClient bot,
        ChatId chatId,
        string description
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost("setChatDescription", new { chatId, description })
        );
}
