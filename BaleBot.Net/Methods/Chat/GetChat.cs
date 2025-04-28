using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<Chat> GetChat(this BaleBotClient bot, ChatId chatId) =>
        await bot.SendRequest<Chat>(BotRequest.CreatePost("getChat", new { chatId }));
}
