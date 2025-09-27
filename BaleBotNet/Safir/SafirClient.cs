using System.Reflection;

namespace BaleBotNet.Safir;

public class SafirClient(string apiAccessKey, int timeout = 10)
{
    private readonly HttpClient httpClient =
        new()
        {
            BaseAddress = new Uri("https://safir.bale.ai/api/v3/"),
            DefaultRequestHeaders =
            {
                { "api-access-key", apiAccessKey },
                {
                    "User-Agent",
                    $"BaleBotNet/{Assembly.GetCallingAssembly().GetName().Version?.ToString(3)}"
                }
            },
            Timeout = TimeSpan.FromSeconds(timeout)
        };

    internal async Task<T> SendRequest<T>(HttpRequestMessage request)
    {
        var response = await httpClient.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();

        T result = Shared.DeserializeFromJson<T>(responseString)!;

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(
                $"Error In {request.RequestUri}",
                new(await Shared.GetRequestBodyForLog(request))
            );
        }

        return result;
    }
}
