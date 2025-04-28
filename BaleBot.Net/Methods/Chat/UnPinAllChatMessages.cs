namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> UnPinAllChatMessages(this BaleBotClient bot, string chatId)
    {
        var request = BotRequest.CreatePost("unpinAllChatMessages", new { chatId });

        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> UnPinAllChatMessages(this BaleBotClient bot, long chatId) =>
        await UnPinAllChatMessages(bot, chatId.ToString());
}
