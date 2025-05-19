using BaleBotNet;
using BaleBotNet.Types;

namespace Sample.UpdateHandlers;

public class PreCheckoutQueryUpdateHandler : IPreCheckoutQueryUpdateHandler
{
    public Task HandleUpdate(
        int updateId,
        PreCheckoutQuery preCheckoutQuery,
        CancellationToken cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }
}
