namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> Logout(this BaleBotClient bot)
    {
        var request = BotRequest.CreateGet("logout");

        return await bot.SendRequest<bool>(request);
    }
}
