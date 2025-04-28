using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> UnPinChatMessage(
        this BaleBotClient bot,
        ChatId chatId,
        long messageId
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost("unPinChatMessage", new { chatId, messageId })
        );
}
