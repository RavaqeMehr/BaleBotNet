using BaleBotNet;
using BaleBotNet.Methods;
using BaleBotNet.Types;

namespace Sample.UpdateHandlers;

public class CallbackQueryUpdateHandler(BaleBotClient bot) : ICallbackQueryUpdateHandler
{
    public async Task HandleUpdate(
        int updateId,
        CallbackQuery callbackQuery,
        CancellationToken cancellationToken = default
    )
    {
        await bot.SendMessage(
            callbackQuery.From.Id,
            $"callbackQuery: {callbackQuery.Data}",
            callbackQuery.Message?.MessageId
        );
    }
}
