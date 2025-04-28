namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> SetChatTitle(this BaleBotClient bot, string chatId, string title)
    {
        var request = BotRequest.CreatePost("setChatTitle", new { chatId, title });
        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> SetChatTitle(
        this BaleBotClient bot,
        long chatId,
        string title
    ) => await SetChatTitle(bot, chatId.ToString(), title);
}
