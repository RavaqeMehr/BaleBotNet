using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> PinChatMessage(
        this BaleBotClient bot,
        ChatId chatId,
        long messageId
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost("pinChatMessage", new { chatId, messageId })
        );
}
