using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using BaleBotNet.Safir.Types;

namespace BaleBotNet.Safir;

public class SafirOtpClient(string username, string password, int timeout = 10)
{
    private string token = "";
    private readonly HttpClient httpClient =
        new()
        {
            BaseAddress = new Uri("https://safir.bale.ai/api/v2/"),
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

    public async Task<bool> InitAuth()
    {
        var dict = new Dictionary<string, string>
        {
            { "grant_type", "client_credentials" },
            { "client_secret", password },
            { "scope", "read" },
            { "client_id", username }
        };

        using FormUrlEncodedContent form = new(dict);

        var result = await SendRequest<TokenResult>(
            new HttpRequestMessage(HttpMethod.Post, "auth/token") { Content = form }
        );

        if (!result.IsSuccess())
            return false;

        token = result.AccessToken!;
        return true;
    }

    public async Task<SendOtpResult> SendOtp(string phone, int otp) =>
        await SendRequest<SendOtpResult>(
            new(HttpMethod.Post, "send_otp")
            {
                Headers = { Authorization = new AuthenticationHeaderValue("Bearer", token) },
                Content = JsonContent.Create(new { phone, otp }, options: Shared.jsonOption)
            }
        );
}
