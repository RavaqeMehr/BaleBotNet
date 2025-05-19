using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> SendLocation(
        this BaleBotClient bot,
        ChatId chatId,
        float latitude,
        float longitude,
        int? horizontalAccuracy = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "sendLocation",
                new
                {
                    chatId,
                    latitude,
                    longitude,
                    horizontalAccuracy,
                    replyToMessageId,
                    replyMarkup
                }
            )
        );
}
