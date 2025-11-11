using BaleBotNet.Methods;
using BaleBotNet.Types;

namespace Sample;

public partial class ShortSamples
{
    public async Task EditKeyboard(long chatId)
    {
        var message = await bot.SendMessage(chatId: chatId, text: "تست ویرایش ReplyMarkup");

        for (int i = 10; i >= 0; i--)
        {
            await Task.Delay(1000);

            await message.EditReplyMarkup(
                bot,
                ReplyKeyboard.CreateInline(
                    [
                        [new() { Text = $"Button {i}", CallbackData = $"btn-{i}" }]
                    ]
                )
            );
        }
    }
}
