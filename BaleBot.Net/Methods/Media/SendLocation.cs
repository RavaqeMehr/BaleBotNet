using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendLocation(
        this BaleBotClient bot,
        string chatId,
        float latitude,
        float longitude,
        int? horizontalAccuracy = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        var request = BotRequest.CreatePost(
            "sendLocation",
            new
            {
                chatId,
                latitude,
                longitude,
                horizontalAccuracy,
                replyToMessageId,
                replyMarkup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
            }
        );

        return await bot.SendRequest<Message>(request);
    }

    public static async Task<Message> SendLocation(
        this BaleBotClient bot,
        long chatId,
        float latitude,
        float longitude,
        int? horizontalAccuracy = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendLocation(
            bot,
            chatId.ToString(),
            latitude,
            longitude,
            horizontalAccuracy,
            replyToMessageId,
            replyMarkup
        );
}
