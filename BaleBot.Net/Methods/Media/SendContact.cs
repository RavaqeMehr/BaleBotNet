using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendContact(
        this BaleBotClient bot,
        string chatId,
        string phoneNumber,
        string firstName,
        string? lastName = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        var request = BotRequest.CreatePost(
            "sendContact",
            new
            {
                chatId,
                phoneNumber,
                firstName,
                lastName,
                replyToMessageId,
                replyMarkup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
            }
        );

        return await bot.SendRequest<Message>(request);
    }

    public static async Task<Message> SendContact(
        this BaleBotClient bot,
        long chatId,
        string phoneNumber,
        string firstName,
        string? lastName = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await SendContact(
            bot,
            chatId.ToString(),
            phoneNumber,
            firstName,
            lastName,
            replyToMessageId,
            replyMarkup
        );
}
