using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> SetChatDescription(
        this BaleBotClient bot,
        string chatId,
        string description
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "setChatDescription")
        {
            Content = JsonContent.Create(new { chat_id = chatId, description })
        };

        return await bot.SendRequest<bool>(request);
    }
}
