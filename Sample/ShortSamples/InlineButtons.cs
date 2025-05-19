using BaleBotNet.Methods;
using BaleBotNet.Types;

namespace Sample;

public partial class ShortSamples
{
    public async Task InlineButtons(long chatId)
    {
        await bot.SendMessage(
            chatId: chatId,
            text: "test",
            replyMarkup: ReplyKeyboard.CreateInline(
                [
                    [ // چند دکمه در هر سطر
                        new() { Text = "کال‌بک 1", CallbackData = "call-back-1" },
                        new() { Text = "کال‌بک 2", CallbackData = "call-back-2" }
                    ],
                    [new() { Text = "باز کردن لینک", Url = "https://ble.ir/BaleBotNet" }],
                    [
                        new()
                        {
                            Text = "باز کردن مینی‌اپ",
                            WebApp = new() { Url = "https://mini-app.com/" }
                        }
                    ],
                    [
                        new()
                        {
                            Text = "کپی کد تخفیف",
                            CopyText = new() { Text = "off-123" }
                        }
                    ]
                ]
            )
        );
    }
}
