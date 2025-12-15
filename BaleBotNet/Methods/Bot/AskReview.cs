namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> AskReview(
        this BaleBotClient bot,
        long userId,
        int delaySeconds
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost("askReview", new { userId, delaySeconds })
        );
}
