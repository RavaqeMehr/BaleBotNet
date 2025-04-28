using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

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
