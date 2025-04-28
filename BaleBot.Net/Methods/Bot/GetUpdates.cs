using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Update[]> GetUpdates(
        this BaleBotClient bot,
        int? offset = null,
        int? limit = null
    ) =>
        await bot.SendRequest<Update[]>(BotRequest.CreatePost("getUpdates", new { offset, limit }));
}
