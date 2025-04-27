using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<WebhookInfo> GetWebhookInfo(this BaleBotClient bot)
    {
        var request = BotRequest.CreateGet("getWebhookInfo");

        return await bot.SendRequest<WebhookInfo>(request);
    }
}
