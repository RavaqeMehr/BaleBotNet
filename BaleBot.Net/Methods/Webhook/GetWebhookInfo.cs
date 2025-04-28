using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<WebhookInfo> GetWebhookInfo(this BaleBotClient bot) =>
        await bot.SendRequest<WebhookInfo>(BotRequest.CreateGet("getWebhookInfo"));
}
