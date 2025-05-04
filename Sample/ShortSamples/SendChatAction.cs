using BaleBot.Net.Enums;
using BaleBot.Net.Methods;

namespace Sample;

public partial class ShortSamples
{
    public async Task SendChatAction(long chatId)
    {
        await bot.SendChatAction(chatId: chatId, action: ChatAction.Typing);
    }
}
