using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> EditMessageReplyMarkup(
        this BaleBotClient bot,
        ChatId chatId,
        long messageId,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "editMessageReplyMarkup",
                new
                {
                    chatId,
                    messageId,
                    replyMarkup
                }
            )
        );
}

public static partial class MessageExtentions
{
    public static async Task<Message> EditReplyMarkup(
        this Message message,
        BaleBotClient bot,
        IReplyMarkup? replyMarkup = null
    ) => await bot.EditMessageReplyMarkup(message.Chat.Id, message.MessageId, replyMarkup);
}
