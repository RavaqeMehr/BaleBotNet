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
        var request = BotRequest.CreatePost(
            "sendInvoice",
            new
            {
                chatId,
                title,
                description,
                payload,
                providerToken,
                prices = BaleBotClient.SerializeToJson(prices),
                photoUrl,
                replyToMessageId
            }
        );

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
