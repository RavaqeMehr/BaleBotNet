using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> UnPinChatMessage(
        this BaleBotClient bot,
        string chatId,
        long messageId
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "unPinChatMessage")
        {
            Content = JsonContent.Create(new { chat_id = chatId, message_id = messageId })
        };

        return await bot.SendRequest<bool>(request);
    }
}
