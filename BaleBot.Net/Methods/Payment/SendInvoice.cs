using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendInvoice(
        this BaleBotClient bot,
        string chatId,
        string title,
        string description,
        string payload,
        string providerToken,
        LabeledPrice[] prices,
        string? photoUrl = null,
        long? replyToMessageId = null
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "sendInvoice")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    title,
                    description,
                    payload,
                    provider_token = providerToken,
                    prices = BaleBotClient.SerializeToJson(prices),
                    photo_url = photoUrl,
                    reply_to_message_id = replyToMessageId
                }
            )
        };

        return await bot.SendRequest<Message>(request);
    }

    public static async Task<Message> SendInvoice(
        this BaleBotClient bot,
        long chatId,
        string title,
        string description,
        string payload,
        string providerToken,
        LabeledPrice[] prices,
        string? photoUrl = null,
        long? replyToMessageId = null
    ) =>
        await SendInvoice(
            bot,
            chatId.ToString(),
            title,
            description,
            payload,
            providerToken,
            prices,
            photoUrl,
            replyToMessageId
        );
}
