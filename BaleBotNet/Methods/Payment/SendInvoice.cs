using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> SendInvoice(
        this BaleBotClient bot,
        ChatId chatId,
        string title,
        string description,
        string payload,
        string providerToken,
        LabeledPrice[] prices,
        string? photoUrl = null,
        long? replyToMessageId = null
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
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
            )
        );
}
