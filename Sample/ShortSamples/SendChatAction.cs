using BaleBotNet.Enums;
using BaleBotNet.Methods;

namespace Sample;

public partial class ShortSamples
{
    public async Task SendChatAction(long chatId)
    {
        var actions = Enum.GetValues<ChatAction>();

        foreach (var action in actions)
        {
            await bot.SendMessage(chatId, action.ToString());
            await bot.SendChatAction(chatId: chatId, action: action);
            await Task.Delay(2000);
        }
    }
}
