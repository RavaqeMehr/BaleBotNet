using System.Reflection;
using BaleBotNet.Types;

namespace BaleBotNet;

public partial class BaleBotClient(string token, int timeout = 60)
{
    public readonly string Token = token;

    private readonly HttpClient httpClient =
        new()
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

    internal async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
#if DEBUG
        Console.WriteLine($"{GetReqeustMethodAndUriForLog(request, false)} : ----------------");
        Console.WriteLine(await Shared.GetRequestBodyForLog(request));
#endif

        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();

#if DEBUG
        Console.WriteLine(
            $"Headers : {Shared.SerializeToJson(response.RequestMessage?.Headers.ToDictionary())}"
        );
        Console.WriteLine($"Response : ----------------");
        Console.WriteLine(responseString);
        Console.WriteLine("----------------");
#endif

        Response<T> result = Shared.DeserializeFromJson<Response<T>>(responseString)!;

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Error In {GetReqeustMethodAndUriForLog(request, true)}: {result.Description} ({result.ErrorCode})",
                new(await Shared.GetRequestBodyForLog(request))
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

    public async Task<Stream> StreamDownloader(string fileUrl)
    {
        return await httpClient.GetStreamAsync(fileUrl);
    }
}
