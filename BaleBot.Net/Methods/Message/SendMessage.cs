using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> SendMessage(
        this BaleBotClient bot,
        string chatId,
        string text,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    )
    {
        var request = BotRequest.CreatePost(
            "sendMessage",
            new
            {
                chatId,
                text,
                replyToMessageId,
                replyMarkup
            }
        );

        return await bot.SendRequest<Message>(request);
    }

    public static async Task<Message> SendMessage(
        this BaleBotClient bot,
        long chatId,
        string text,
        long? replyToMessageId = null,
        IReplyMarkup? replyMarkup = null
    ) => await SendMessage(bot, chatId.ToString(), text, replyToMessageId, replyMarkup);
}
