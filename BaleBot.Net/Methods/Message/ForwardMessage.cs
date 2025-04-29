using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> ForwardMessage(
        this BaleBotClient bot,
        ChatId chatId,
        long fromChatId,
        long messageId
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "forwardMessage",
                new
                {
                    chatId,
                    fromChatId,
                    messageId
                }
            )
        );
}

public static partial class MessageExtentions
{
    public static async Task<Message> ForwardTo(
        this Message message,
        BaleBotClient bot,
        ChatId chatId
    ) => await bot.ForwardMessage(chatId, message.Chat.Id, message.MessageId);
}
