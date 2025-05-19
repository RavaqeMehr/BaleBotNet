using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> EditMessage(
        this BaleBotClient bot,
        ChatId chatId,
        long messageId,
        string text,
        IReplyMarkup? replyMarkup = null
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "editMessageText",
                new
                {
                    chatId,
                    messageId,
                    text,
                    replyMarkup
                }
            )
        );
}

public static partial class MessageExtentions
{
    public static async Task<Message> Edit(
        this Message message,
        BaleBotClient bot,
        string text,
        IReplyMarkup? replyMarkup = null
    ) => await bot.EditMessage(message.Chat.Id, message.MessageId, text, replyMarkup);
}
