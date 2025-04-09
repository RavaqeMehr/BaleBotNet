using System.Text.Json;

namespace BaleBot.Net;

public class BaleBotClient(string token)
{
    public readonly string Token = token;

    public readonly HttpClient httpClient = new HttpClient
    {
        BaseAddress = new Uri($"https://tapi.bale.ai/bot{token}/")
    };

    public readonly JsonSerializerOptions jsonOption =
        new(JsonSerializerOptions.Default)
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
}
