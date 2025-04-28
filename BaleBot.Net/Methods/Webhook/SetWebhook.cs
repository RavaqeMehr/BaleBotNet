namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> SetWebhook(this BaleBotClient bot, string url) =>
        await bot.SendRequest<bool>(BotRequest.CreatePost("setWebhook", new { url }));
}
