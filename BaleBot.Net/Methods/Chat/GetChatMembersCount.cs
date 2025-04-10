using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<int> GetChatMembersCount(this BaleBotClient bot, string chatId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "getChatMembersCount")
        {
            Content = JsonContent.Create(new { chat_id = chatId })
        };

        return await bot.SendRequest<int>(request);
    }
}
