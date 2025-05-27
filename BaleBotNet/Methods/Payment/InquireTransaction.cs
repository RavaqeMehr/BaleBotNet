using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Transaction> InquireTransaction(
        this BaleBotClient bot,
        string transactionId
    ) =>
        await bot.SendRequest<Transaction>(
            BotRequest.CreatePost("inquireTransaction", new { transactionId })
        );
}
