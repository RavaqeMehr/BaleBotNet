using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> CreateNewStickerSet(
        this BaleBotClient bot,
        long userId,
        string name,
        string title,
        Sticker[] stickers
    )
    {
        var me = await bot.GetMe();

        var request = BotRequest.CreatePost(
            "createNewStickerSet",
            new
            {
                userId,
                name = $"{name}_by_{me.Username}",
                title,
                sticker = BaleBotClient.SerializeToJson(stickers)
            }
        );

        return await bot.SendRequest<bool>(request);
    }
}
