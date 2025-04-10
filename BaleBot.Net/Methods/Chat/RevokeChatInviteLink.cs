using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<string> RevokeChatInviteLink(
        this BaleBotClient bot,
        string chatId,
        string inviteLink
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "revokeChatInviteLink")
        {
            Content = JsonContent.Create(new { chat_id = chatId, invite_link = inviteLink })
        };

        return await bot.SendRequest<string>(request);
    }
}
