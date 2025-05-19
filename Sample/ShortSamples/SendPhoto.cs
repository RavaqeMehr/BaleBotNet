using BaleBotNet.Methods;

namespace Sample;

public partial class ShortSamples
{
    public async Task SendPhoto(long chatId)
    {
        await bot.SendPhoto(
            chatId: chatId,
            "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Persian_Leopard_sitting.jpg/960px-Persian_Leopard_sitting.jpg"
        );

        await bot.SendPhoto(
            chatId: chatId,
            "1562583495:-8733407888411910398:1:d18b50f5a9e86db61568e3a0bac7d63db67413c30bfef7f61f2372db3d95090e3c7b7805ace94705"
        );

        await bot.SendPhoto(chatId: chatId, new FileInfo(@"assets\bale.webp"));
    }
}
