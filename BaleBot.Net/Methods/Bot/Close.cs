namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> Close(this BaleBotClient bot, bool clearWebhookBeforeClose)
    {
        if (clearWebhookBeforeClose)
        {
            await bot.DeleteWebhook();
        }

        return await bot.SendRequest<bool>(BotRequest.CreateGet("close"));
    }
}
