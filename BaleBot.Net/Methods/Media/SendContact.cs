using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendContact(
        this BaleBotClient bot,
        long chatId,
        string phoneNumber,
        string firstName,
        string? lastName = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "sendContact")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    phone_number = phoneNumber,
                    first_name = firstName,
                    last_name = lastName,
                    reply_to_message_id = replyToMessageId,
                    reply_markup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
                }
            )
        };

        return await bot.SendRequest<Message>(request);
    }
}
