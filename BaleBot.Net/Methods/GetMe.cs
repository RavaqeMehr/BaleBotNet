using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<User> GetMe(this BaleBotClient bot)
    {
        var response = await bot.httpClient.GetAsync("getme");
        Response<User> result = (
            await response.Content.ReadFromJsonAsync<Response<User>>(bot.jsonOption)
        )!;

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"GetMe Error: {result.Description} ({result.ErrorCode})"
            );
        }

        return result.Result!;
    }
}
