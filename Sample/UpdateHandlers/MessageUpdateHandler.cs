using BaleBotNet;
using BaleBotNet.Enums;
using BaleBotNet.Methods;
using BaleBotNet.Types;

namespace Sample.UpdateHandlers;

public class MessageUpdateHandler(BaleBotClient bot) : IMessageUpdateHandler
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

        await bot.SendMessage(
            message.Chat.Id,
            message.Text ?? "Emptey text",
            message.MessageId,
            new InlineKeyboardMarkup
            {
                InlineKeyboard =
                [
                    [new() { Text = "Test Callback", CallbackData = "test-callback" }]
                ]
            }
        );
    }
}
