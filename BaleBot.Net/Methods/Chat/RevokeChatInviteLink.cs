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
        var request = BotRequest.CreatePost("revokeChatInviteLink", new { chatId, inviteLink });
        return await bot.SendRequest<InviteLinkResponse>(request);
    }

    public static async Task<InviteLinkResponse> RevokeChatInviteLink(
        this BaleBotClient bot,
        long chatId,
        string inviteLink
    ) => await RevokeChatInviteLink(bot, chatId.ToString(), inviteLink);
}
