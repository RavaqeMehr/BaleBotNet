using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> CopyMessage(
        this BaleBotClient bot,
        ChatId chatId,
        ChatId fromChatId,
        long messageId
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "copyMessage",
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
    public static async Task<Message> CopyTo(
        this Message message,
        BaleBotClient bot,
        ChatId chatId
    ) => await bot.CopyMessage(chatId, message.Chat.Id, message.MessageId);
}
