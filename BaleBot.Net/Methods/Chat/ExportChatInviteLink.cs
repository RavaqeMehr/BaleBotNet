using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<string> ExportChatInviteLink(this BaleBotClient bot, string chatId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "exportChatInviteLink")
        {
            Content = JsonContent.Create(new { chat_id = chatId })
        };

        return await bot.SendRequest<string>(request);
    }

    public static async Task<string> ExportChatInviteLink(this BaleBotClient bot, long chatId) =>
        await ExportChatInviteLink(bot, chatId.ToString());
}
