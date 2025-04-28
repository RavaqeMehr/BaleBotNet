namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<int> GetChatMembersCount(this BaleBotClient bot, string chatId)
    {
        var request = BotRequest.CreatePost("getChatMembersCount", new { chatId });

        return await bot.SendRequest<int>(request);
    }

    public static async Task<int> GetChatMembersCount(this BaleBotClient bot, long chatId) =>
        await GetChatMembersCount(bot, chatId.ToString());
}
