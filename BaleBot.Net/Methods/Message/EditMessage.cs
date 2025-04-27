using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> EditMessage(
        this BaleBotClient bot,
        string chatId,
        long messageId,
        string text,
        IReplyMarkup? replyMarkup = null
    )
    {
        var request = BotRequest.CreatePost(
            "editMessageText",
            new
            {
                chatId,
                messageId,
                text,
                replyMarkup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
            }
        );

        return await bot.SendRequest<Message>(request);
    }

    public static async Task<Message> EditMessage(
        this BaleBotClient bot,
        long chatId,
        long messageId,
        string text,
        IReplyMarkup? replyMarkup = null
    ) => await EditMessage(bot, chatId.ToString(), messageId, text, replyMarkup);
}
