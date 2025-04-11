using System.Net.Http.Json;
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
        var request = new HttpRequestMessage(HttpMethod.Post, "copyMessage")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    from_chat_id = fromChatId,
                    message_id = messageId
                }
            )
        };

        return await bot.SendRequest<Message>(request);
    }
}
