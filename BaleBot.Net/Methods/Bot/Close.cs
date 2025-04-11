namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> Close(this BaleBotClient bot, bool clearWebhookBeforeClose)
    {
        if (clearWebhookBeforeClose)
        {
            await bot.DeleteWebhook();
        }
        var request = new HttpRequestMessage(HttpMethod.Get, "close");

        return await bot.SendRequest<bool>(request);
    }
}
