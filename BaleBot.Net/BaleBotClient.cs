using System.Net.Http.Json;
using System.Text.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net;

public class BaleBotClient(string token)
{
    public readonly string Token = token;

    private readonly HttpClient httpClient = new HttpClient
    {
        BaseAddress = new Uri($"https://tapi.bale.ai/bot{token}/")
    };

    public readonly JsonSerializerOptions jsonOption =
        new(JsonSerializerOptions.Default)
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

    public async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
        var response = await httpClient.SendAsync(request);
        Response<T> result = (await response.Content.ReadFromJsonAsync<Response<T>>(jsonOption))!;

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"SendRequest [{request.RequestUri!.LocalPath.Replace(Token, "").Replace("//", "/").Replace("/bot", "")}] Error: {result.Description} ({result.ErrorCode})"
            );
        }

        return result.Result!;
    }
}
