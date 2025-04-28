namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> LeaveChat(this BaleBotClient bot, string chatId)
    {
        var request = BotRequest.CreatePost("leaveChat", new { chatId });
        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> LeaveChat(this BaleBotClient bot, long chatId) =>
        await LeaveChat(bot, chatId.ToString());
}
