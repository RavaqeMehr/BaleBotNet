using System.Net.Http.Json;

namespace BaleBotNet;

public static class BotRequest
{
    public static HttpRequestMessage CreatePost(string path, object jsonBody) =>
        new(HttpMethod.Post, path)
        {
            Content = JsonContent.Create(jsonBody, options: BaleBotClient.jsonOption)
        };

    public static HttpRequestMessage CreateGet(string path) => new(HttpMethod.Get, path);

    public static HttpRequestMessage CreateForm(string path, MultipartFormDataContent form) =>
        new(HttpMethod.Post, path) { Content = form };
}
