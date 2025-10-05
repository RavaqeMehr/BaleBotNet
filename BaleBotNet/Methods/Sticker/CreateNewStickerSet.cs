using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<bool> CreateNewStickerSet(
        this BaleBotClient bot,
        long userId,
        string name,
        string title,
        Sticker[] stickers
    ) =>
        await bot.SendRequest<bool>(
            BotRequest.CreatePost(
                "createNewStickerSet",
                new
                {
                    userId,
                    name = $"{name}_by_{bot.Me.Username}",
                    title,
                    sticker = BaleBotNetJsonTools.SerializeToJson(stickers)
                }
            )
        );
}
