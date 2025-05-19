using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<string> ExportChatInviteLink(this BaleBotClient bot, ChatId chatId) =>
        await bot.SendRequest<string>(
            BotRequest.CreatePost("exportChatInviteLink", new { chatId })
        );
}
