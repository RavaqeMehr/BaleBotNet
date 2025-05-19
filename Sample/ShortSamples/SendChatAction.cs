using BaleBotNet.Enums;
using BaleBotNet.Methods;

namespace Sample;

public partial class ShortSamples
{
    public async Task SendChatAction(long chatId)
    {
        await bot.SendChatAction(chatId: chatId, action: ChatAction.Typing);
    }
}
