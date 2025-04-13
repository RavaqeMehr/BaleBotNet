using System.Net.Http.Json;
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
        var request = new HttpRequestMessage(HttpMethod.Post, "editMessageText")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    message_id = messageId,
                    text,
                    reply_markup = replyMarkup?.Serialize() ?? "{\"keyboard\":\"[[]]\"}"
                }
            )
        };

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
