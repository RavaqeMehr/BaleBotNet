using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> LeaveChat(this BaleBotClient bot, ChatId chatId) =>
        await bot.SendRequest<bool>(BotRequest.CreatePost("leaveChat", new { chatId }));
}
