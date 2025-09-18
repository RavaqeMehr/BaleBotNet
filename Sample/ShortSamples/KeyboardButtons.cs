using BaleBotNet.Methods;
using BaleBotNet.Types;

namespace Sample;

public partial class ShortSamples
{
    public async Task KeyboardButtons(long chatId)
    {
        var replyMarkup = ReplyKeyboard.CreateKeyboard(
            [
                [ // چند دکمه در هر سطر
                    new() { Text = "Option 1" },
                    new() { Text = "Option 2" }
                ],
                [new() { Text = "Cancel ❌" }]
            ]
        );

        var message = await bot.SendMessage(
            chatId: chatId,
            text: "Choose an option:",
            replyMarkup: replyMarkup
        );

        var saveChatMarkup = new { chatId, replyMarkup }; // can save chat replyMarkup if needed
    }
}
