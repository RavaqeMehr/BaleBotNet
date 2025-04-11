using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendMessage(
        this BaleBotClient bot,
        string chatId,
        string text,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "sendMessage")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    text,
                    reply_to_message_id = replyToMessageId,
                    reply_markup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
                }
            )
        };

        return await bot.SendRequest<Message>(request);
    }
}
