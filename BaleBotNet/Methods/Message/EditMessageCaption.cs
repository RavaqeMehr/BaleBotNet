using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> EditMessageCaption(
        this BaleBotClient bot,
        ChatId chatId,
        long messageId,
        string? caption,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "editMessageCaption",
                new
                {
                    chatId,
                    messageId,
                    caption,
                    replyMarkup
                }
            )
        );
}

public static partial class MessageExtentions
{
    public static async Task<Message> EditCaption(
        this Message message,
        BaleBotClient bot,
        string? caption,
        IReplyMarkup? replyMarkup = null
    ) => await bot.EditMessageCaption(message.Chat.Id, message.MessageId, caption, replyMarkup);
}
