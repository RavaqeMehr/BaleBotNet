using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<User> GetMe(this BaleBotClient bot) =>
        await bot.SendRequest<User>(BotRequest.CreateGet("getme"));
}
