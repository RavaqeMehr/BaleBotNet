namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> DeleteWebhook(this BaleBotClient bot) =>
        await bot.SetWebhook(string.Empty);
}
