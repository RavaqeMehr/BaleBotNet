using BaleBotNet.Methods;

namespace Sample;

public partial class ShortSamples
{
    public async Task AskReview(long userId)
    {
        var result = await bot.AskReview(userId, 1);

        Console.WriteLine($"AskReview Result: {result}");
    }
}
