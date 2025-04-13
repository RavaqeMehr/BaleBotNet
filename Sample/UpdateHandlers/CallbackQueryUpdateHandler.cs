using BaleBot.Net;
using BaleBot.Net.Methods;
using BaleBot.Net.Types;

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
