using System.Net.Http.Json;
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
        var request = new HttpRequestMessage(HttpMethod.Post, "sendLocation")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    latitude,
                    longitude,
                    horizontal_accuracy = horizontalAccuracy,
                    reply_to_message_id = replyToMessageId,
                    reply_markup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
                }
            )
        };

        return await bot.SendRequest<Message>(request);
    }
}
