using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    /// <param name="timeout">seconds</param>
    public static async Task<Update[]> GetUpdates(
        this BaleBotClient bot,
        int? offset = null,
        int? limit = null,
        int? timeout = null
    ) =>
        await bot.SendRequest<Update[]>(
            BotRequest.CreatePost(
                "getUpdates",
                new
                {
                    offset,
                    limit,
                    timeout
                }
            )
        );
}
