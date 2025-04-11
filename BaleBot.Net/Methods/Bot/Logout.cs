using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> Logout(this BaleBotClient bot)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "logout");

        return await bot.SendRequest<bool>(request);
    }
}
