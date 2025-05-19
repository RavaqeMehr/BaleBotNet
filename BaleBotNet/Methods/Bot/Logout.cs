namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> Logout(this BaleBotClient bot) =>
        await bot.SendRequest<bool>(BotRequest.CreateGet("logout"));
}
