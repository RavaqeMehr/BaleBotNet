using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<User> GetMe(this BaleBotClient bot) =>
        await bot.SendRequest<User>(BotRequest.CreateGet("getme"));
}
