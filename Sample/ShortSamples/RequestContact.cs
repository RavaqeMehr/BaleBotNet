using BaleBotNet.Methods;
using BaleBotNet.Types;

namespace Sample;

public partial class ShortSamples
{
    public async Task RequestContact(long chatId)
    {
        await bot.SendMessage(
            chatId: chatId,
            text: "test",
            replyMarkup: ReplyKeyboard.CreateKeyboard(
                [
                    [new() { Text = "ارسال شماره موبایل", RequestContact = true }]
                ]
            )
        );
    }
}
