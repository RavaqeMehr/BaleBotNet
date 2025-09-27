using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Message> AddStickerToSet(
        this BaleBotClient bot,
        long userId,
        string name,
        Sticker sticker
    ) =>
        await bot.SendRequest<Message>(
            BotRequest.CreatePost(
                "addStickerToSet",
                new
                {
                    userId,
                    name,
                    sticker = Shared.SerializeToJson(sticker)
                }
            )
        );
}
