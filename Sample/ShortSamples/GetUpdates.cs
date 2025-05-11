using BaleBot.Net.Methods;
using BaleBot.Net.Types;

namespace Sample;

public partial class ShortSamples
{
    public async Task GetUpdates(
        Func<Update, Task> updateHandler,
        CancellationToken cancellationToken
    )
    {
        int? offset = null;
        int limit = 10; //  fetch 10 update per request
        int timeout = 5; // 5 sec

        do
        {
            var updates = await bot.GetUpdates(offset, limit, timeout);
            if (updates?.Length > 0)
            {
                await Task.WhenAll(updates!.Select(updateHandler));

                offset = updates?.Last().UpdateId + 1;
            }

            await Task.Delay(timeout * 1000);
        } while (!cancellationToken.IsCancellationRequested);
    }
}
