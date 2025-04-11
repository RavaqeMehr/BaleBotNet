using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> AnswerPreCheckoutQuery(
        this BaleBotClient bot,
        string preCheckoutQueryId,
        bool ok,
        string? errorMessage
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "answerPreCheckoutQuery")
        {
            Content = JsonContent.Create(
                new
                {
                    pre_checkout_query_id = preCheckoutQueryId,
                    ok,
                    error_message = errorMessage
                }
            )
        };

        return await bot.SendRequest<bool>(request);
    }
}
