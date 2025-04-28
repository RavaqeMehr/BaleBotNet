using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

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
                    replyMarkup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
                }
            )
        );
}
