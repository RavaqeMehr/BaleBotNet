namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<string> ExportChatInviteLink(this BaleBotClient bot, string chatId)
    {
        var request = BotRequest.CreatePost("exportChatInviteLink", new { chatId });

        return await bot.SendRequest<string>(request);
    }

    public static async Task<string> ExportChatInviteLink(this BaleBotClient bot, long chatId) =>
        await ExportChatInviteLink(bot, chatId.ToString());
}
