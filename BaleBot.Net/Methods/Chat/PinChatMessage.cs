namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> PinChatMessage(
        this BaleBotClient bot,
        string chatId,
        long messageId
    )
    {
        var request = BotRequest.CreatePost("pinChatMessage", new { chatId, messageId });

        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> PinChatMessage(
        this BaleBotClient bot,
        long chatId,
        long messageId
    ) => await PinChatMessage(bot, chatId.ToString(), messageId);
}
