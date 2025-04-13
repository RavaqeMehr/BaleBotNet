using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Update[]> GetUpdates(
        this BaleBotClient bot,
        int? offset = null,
        int? limit = null
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "getUpdates")
        {
            Content = JsonContent.Create(new { offset, limit })
        };

        return await bot.SendRequest<Update[]>(request);
    }
}
