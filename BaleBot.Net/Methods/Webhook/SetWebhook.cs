using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> SetWebhook(this BaleBotClient bot, string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "setWebhook")
        {
            Content = JsonContent.Create(new { url })
        };

        return await bot.SendRequest<bool>(request);
    }
}
