namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> DeleteMessage(
        this BaleBotClient bot,
        string chatId,
        long messageId
    )
    {
        var request = BotRequest.CreatePost("deleteMessage", new { chatId, messageId });

        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> DeleteMessage(
        this BaleBotClient bot,
        long chatId,
        long messageId
    ) => await DeleteMessage(bot, chatId.ToString(), messageId);
}
