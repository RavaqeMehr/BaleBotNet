namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> AnswerPreCheckoutQuery(
        this BaleBotClient bot,
        string preCheckoutQueryId,
        bool ok,
        string? errorMessage = null
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost(
                "answerPreCheckoutQuery",
                new
                {
                    preCheckoutQueryId,
                    ok,
                    errorMessage
                }
            )
        );
}
