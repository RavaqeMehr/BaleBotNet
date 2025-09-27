using System.Net.Http.Json;
using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<ChatFullInfo> GetChat(this BaleBotClient bot, ChatId chatId) =>
        await bot.SendRequest<ChatFullInfo>(BotRequest.CreatePost("getChat", new { chatId }));
}
