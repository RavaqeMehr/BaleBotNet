using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<string> CreateChatInviteLink(this BaleBotClient bot, string chatId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "createChatInviteLink")
        {
            Content = JsonContent.Create(new { chat_id = chatId })
        };

        return await bot.SendRequest<string>(request);
    }
}
