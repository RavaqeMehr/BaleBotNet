using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Message> AddStickerToSet(
        this BaleBotClient bot,
        long userId,
        string name,
        Sticker sticker
    )
    {
        var request = BotRequest.CreatePost(
            "addStickerToSet",
            new
            {
                userId,
                name,
                sticker = BaleBotClient.SerializeToJson(sticker)
            }
        );

        return await bot.SendRequest<Message>(request);
    }
}
