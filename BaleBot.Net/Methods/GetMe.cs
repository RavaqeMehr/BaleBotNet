using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<User> GetMe(this BaleBotClient bot)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "getme")
        {
            Headers = { { "Accept", "application/json" }, { "User-Agent", "BaleBot.Net" } }
        };

        return await bot.SendRequest<User>(request);
    }
}
