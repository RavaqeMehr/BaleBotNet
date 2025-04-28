namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> SetChatDescription(
        this BaleBotClient bot,
        string chatId,
        string description
    )
    {
        var request = BotRequest.CreatePost("setChatDescription", new { chatId, description });
        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> SetChatDescription(
        this BaleBotClient bot,
        long chatId,
        string description
    ) => await SetChatDescription(bot, chatId.ToString(), description);
}
