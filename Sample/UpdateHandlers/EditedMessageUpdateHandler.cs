using BaleBot.Net;
using BaleBot.Net.Enums;
using BaleBot.Net.Methods;
using BaleBot.Net.Types;

namespace Sample.UpdateHandlers;

public class EditedMessageUpdateHandler(BaleBotClient bot) : IEditedMessageUpdateHandler
{
    public async Task HandleUpdate(
        int updateId,
        Message message,
        CancellationToken cancellationToken = default
    )
    {
        if (message.Chat.Type is not ChatType.Private)
        {
            return;
        }

        await bot.CopyMessage(message.Chat.Id, message.Chat.Id, message.MessageId);
    }
}
