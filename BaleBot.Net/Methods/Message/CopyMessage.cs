using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> CopyMessage(
        this BaleBotClient bot,
        string chatId,
        long fromChatId,
        long messageId
    )
    {
        var request = BotRequest.CreatePost(
            "copyMessage",
            new
            {
                chatId,
                fromChatId,
                messageId
            }
        );

        return await bot.SendRequest<Message>(request);
    }

    public static async Task<Message> CopyMessage(
        this BaleBotClient bot,
        long chatId,
        long fromChatId,
        long messageId
    ) => await CopyMessage(bot, chatId.ToString(), fromChatId, messageId);
}
