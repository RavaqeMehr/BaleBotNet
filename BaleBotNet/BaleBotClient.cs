using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using BaleBotNet.Types;

namespace BaleBotNet;

public partial class BaleBotClient(string token, int timeout = 60)
{
    public readonly string Token = token;

    private readonly HttpClient httpClient = new HttpClient
    {
        BaseAddress = new Uri($"https://tapi.bale.ai/bot{token}/"),
        DefaultRequestHeaders =
        {
            {
                "User-Agent",
                $"BaleBotNet/{Assembly.GetCallingAssembly().GetName().Version?.ToString(3)}"
            }
        },
        Timeout = TimeSpan.FromSeconds(timeout)
    };

    public static readonly JsonSerializerOptions jsonOption =
        new(JsonSerializerOptions.Default)
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.Create(
                [UnicodeRanges.BasicLatin, UnicodeRanges.GeneralPunctuation, UnicodeRanges.Arabic]
            ),
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower) }
        };

    public static readonly JsonSerializerOptions jsonOptionIndented =
        new(jsonOption) { WriteIndented = true };

    internal async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
#if DEBUG
        Console.WriteLine($"{GetReqeustMethodAndUriForLog(request, false)} : ----------------");
        Console.WriteLine(await GetRequestBodyForLog(request));
#endif

        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();

#if DEBUG
        Console.WriteLine(
            $"Headers : {SerializeToJson(response.RequestMessage?.Headers.ToDictionary())}"
        );
        Console.WriteLine($"Response : ----------------");
        Console.WriteLine(responseString);
        Console.WriteLine("----------------");
#endif

        Response<T> result = DeserializeFromJson<Response<T>>(responseString)!;

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Error In {GetReqeustMethodAndUriForLog(request, true)}: {result.Description} ({result.ErrorCode})",
                new(await GetRequestBodyForLog(request))
            );
        }

        return result.Result!;
    }

    private string GetReqeustMethodAndUriForLog(HttpRequestMessage request, bool suppressToken)
    {
        if (suppressToken)
        {
            var uri = request
                .RequestUri!.LocalPath.Replace(Token, "")
                .Replace("//", "/")
                .Replace("/bot", "");
            return $"{request.Method.Method.ToUpper()} [{uri}]";
        }
        else
        {
            return $"{request.Method.Method.ToUpper()} [{request.RequestUri}]";
        }
    }

    private async Task<string> GetRequestBodyForLog(HttpRequestMessage request)
    {
        return request.Content != null
            ? await request.Content.ReadAsStringAsync()
            : "Empty Request Body";
    }

    public async Task<Stream> StreamDownloader(string fileUrl)
    {
        return await httpClient.GetStreamAsync(fileUrl);
    }

    public static string? SerializeToJson<T>(T? obj, bool indented = false)
    {
        if (obj == null)
            return null;
        if (indented)
            return JsonSerializer.Serialize(obj, jsonOptionIndented);
        return JsonSerializer.Serialize(obj, jsonOption);
    }

    public static T? DeserializeFromJson<T>(string? json)
    {
        if (json == null)
            return default;
        return JsonSerializer.Deserialize<T>(json, jsonOption);
    }
}
