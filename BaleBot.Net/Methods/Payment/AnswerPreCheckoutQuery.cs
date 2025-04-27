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
        var request = BotRequest.CreatePost(
            "answerPreCheckoutQuery",
            new
            {
                preCheckoutQueryId,
                ok,
                errorMessage
            }
        );

        return await bot.SendRequest<bool>(request);
    }
}
