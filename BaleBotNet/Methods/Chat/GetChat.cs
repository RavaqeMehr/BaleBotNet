using System.Net.Http.Json;
using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<Chat> GetChat(this BaleBotClient bot, ChatId chatId) =>
        await bot.SendRequest<Chat>(BotRequest.CreatePost("getChat", new { chatId }));
}
