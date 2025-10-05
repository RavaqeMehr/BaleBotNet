using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace BaleBotNet;

public static class BaleBotNetJsonTools
{
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

    internal static async Task<string> GetRequestBodyForLog(HttpRequestMessage request)
    {
        return request.Content != null
            ? await request.Content.ReadAsStringAsync()
            : "Empty Request Body";
    }
}
