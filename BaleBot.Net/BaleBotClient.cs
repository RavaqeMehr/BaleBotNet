using System.Net.Http.Json;
using System.Text.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net;

public class BaleBotClient(string token)
{
    public readonly string Token = token;

    private readonly HttpClient httpClient = new HttpClient
    {
        BaseAddress = new Uri($"https://tapi.bale.ai/bot{token}/"),
        DefaultRequestHeaders = { { "User-Agent", "BaleBot.Net" } },
        Timeout = TimeSpan.FromSeconds(20)
    };

    public static readonly JsonSerializerOptions jsonOption =
        new(JsonSerializerOptions.Default)
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = System
                .Text
                .Json
                .Serialization
                .JsonIgnoreCondition
                .WhenWritingNull
        };

    public async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
#if DEBUG
        Console.WriteLine("----------------");
        Console.WriteLine($"Request [{request.RequestUri}] :");
#endif

        var response = await httpClient.SendAsync(request);
        Response<T> result = (await response.Content.ReadFromJsonAsync<Response<T>>(jsonOption))!;

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"SendRequest [{request.RequestUri!.LocalPath.Replace(Token, "").Replace("//", "/").Replace("/bot", "")}] Error: {result.Description} ({result.ErrorCode})"
            );
        }

#if DEBUG
        Console.WriteLine(SerializeToJson(result));
        Console.WriteLine("----------------");
#endif

        return result.Result!;
    }

    public static string? SerializeToJson<T>(T? obj)
    {
        if (obj == null)
            return null;
        return JsonSerializer.Serialize(obj, jsonOption);
    }
}
