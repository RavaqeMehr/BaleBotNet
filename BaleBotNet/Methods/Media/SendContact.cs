using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> SendContact(
        this BaleBotClient bot,
        ChatId chatId,
        string phoneNumber,
        string firstName,
        string? lastName = null,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "sendContact",
                new
                {
                    chatId,
                    phoneNumber,
                    firstName,
                    lastName,
                    replyToMessageId,
                    replyMarkup
                }
            )
        );
}
