namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> DeleteChatPhoto(this BaleBotClient bot, string chatId)
    {
        var request = BotRequest.CreatePost("deleteChatPhoto", new { chatId });
        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> DeleteChatPhoto(this BaleBotClient bot, long chatId) =>
        await DeleteChatPhoto(bot, chatId.ToString());
}
