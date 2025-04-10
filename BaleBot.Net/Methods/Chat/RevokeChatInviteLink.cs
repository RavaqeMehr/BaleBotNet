using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<InviteLinkResult> RevokeChatInviteLink(
        this BaleBotClient bot,
        string chatId,
        string inviteLink
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "revokeChatInviteLink")
        {
            Content = JsonContent.Create(new { chat_id = chatId, invite_link = inviteLink })
        };

        return await bot.SendRequest<InviteLinkResult>(request);
    }
}
