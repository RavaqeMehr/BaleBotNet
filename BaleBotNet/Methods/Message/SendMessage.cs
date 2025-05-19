using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> SendMessage(
        this BaleBotClient bot,
        ChatId chatId,
        string text,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "sendMessage",
                new
                {
                    chatId,
                    text,
                    replyToMessageId,
                    replyMarkup
                }
            )
        );
}
