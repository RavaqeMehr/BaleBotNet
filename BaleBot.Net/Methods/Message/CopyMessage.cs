using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> CopyMessage(
        this BaleBotClient bot,
        ChatId chatId,
        ChatId fromChatId,
        long messageId
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "copyMessage",
                new
                {
                    chatId,
                    fromChatId,
                    messageId
                }
            )
        );
}
