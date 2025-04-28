using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Chat> GetChat(this BaleBotClient bot, string chatId)
    {
        var request = BotRequest.CreatePost("getChat", new { chatId });

        return await bot.SendRequest<Chat>(request);
    }

    public static async Task<Chat> GetChat(this BaleBotClient bot, long chatId) =>
        await GetChat(bot, chatId.ToString());
}
