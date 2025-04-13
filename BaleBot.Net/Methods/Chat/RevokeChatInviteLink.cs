using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<InviteLinkResponse> RevokeChatInviteLink(
        this BaleBotClient bot,
        string chatId,
        string inviteLink
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "revokeChatInviteLink")
        {
            Content = JsonContent.Create(new { chat_id = chatId, invite_link = inviteLink })
        };

        return await bot.SendRequest<InviteLinkResponse>(request);
    }

    public static async Task<InviteLinkResponse> RevokeChatInviteLink(
        this BaleBotClient bot,
        long chatId,
        string inviteLink
    ) => await RevokeChatInviteLink(bot, chatId.ToString(), inviteLink);
}
