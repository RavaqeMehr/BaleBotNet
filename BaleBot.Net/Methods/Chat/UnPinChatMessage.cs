namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> UnPinChatMessage(
        this BaleBotClient bot,
        string chatId,
        long messageId
    )
    {
        var request = BotRequest.CreatePost("unPinChatMessage", new { chatId, messageId });

        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> UnPinChatMessage(
        this BaleBotClient bot,
        long chatId,
        long messageId
    ) => await UnPinChatMessage(bot, chatId.ToString(), messageId);
}
