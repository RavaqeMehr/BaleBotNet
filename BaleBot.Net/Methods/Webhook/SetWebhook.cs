namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> SetWebhook(this BaleBotClient bot, string url)
    {
        var request = BotRequest.CreatePost("setWebhook", new { url });

        return await bot.SendRequest<bool>(request);
    }
}
