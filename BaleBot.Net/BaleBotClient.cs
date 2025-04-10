using System.Net.Http.Json;
using System.Text.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net;

public class BaleBotClient(string token, int timeout = 60)
{
    public readonly string Token = token;

    private readonly HttpClient httpClient = new HttpClient
    {
        BaseAddress = new Uri($"https://tapi.bale.ai/bot{token}/"),
        DefaultRequestHeaders = { { "User-Agent", "BaleBot.Net" } },
        Timeout = TimeSpan.FromSeconds(timeout)
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
        Console.WriteLine($"Request [{request.RequestUri}] : ----------------");
        Console.WriteLine(
            request.Content != null ? await request.Content.ReadAsStringAsync() : "No Content"
        );
#endif

        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();

#if DEBUG
        Console.WriteLine($"Response : ----------------");
        Console.WriteLine(responseString);
        Console.WriteLine("----------------");
#endif

        Response<T> result = DeserializeFromJson<Response<T>>(responseString)!;

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"SendRequest [{request.RequestUri!.LocalPath.Replace(Token, "").Replace("//", "/").Replace("/bot", "")}] Error: {result.Description} ({result.ErrorCode})"
            );
        }

        return result.Result!;
    }

    public static string? SerializeToJson<T>(T? obj)
    {
        if (obj == null)
            return null;
        return JsonSerializer.Serialize(obj, jsonOption);
    }

    public static T? DeserializeFromJson<T>(string? json)
    {
        if (json == null)
            return default;
        return JsonSerializer.Deserialize<T>(json, jsonOption);
    }
}
