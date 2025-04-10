using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<WebhookInfo> GetWebhookInfo(this BaleBotClient bot)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "getWebhookInfo");

        return await bot.SendRequest<WebhookInfo>(request);
    }
}
