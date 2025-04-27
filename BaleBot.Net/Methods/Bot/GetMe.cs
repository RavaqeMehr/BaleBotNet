using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<User> GetMe(this BaleBotClient bot)
    {
        var request = BotRequest.CreateGet("getme");

        return await bot.SendRequest<User>(request);
    }
}
