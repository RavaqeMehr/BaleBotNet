using System.Net.Http.Json;
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
        var me = await bot.GetMe();

        var request = new HttpRequestMessage(HttpMethod.Post, "addStickerToSet")
        {
            Content = JsonContent.Create(
                new
                {
                    user_id = userId,
                    name,
                    sticker = BaleBotClient.SerializeToJson(sticker)
                }
            )
        };

        return await bot.SendRequest<Message>(request);
    }
}
