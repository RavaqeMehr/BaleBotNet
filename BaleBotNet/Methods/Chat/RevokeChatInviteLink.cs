using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<InviteLinkResponse> RevokeChatInviteLink(
        this BaleBotClient bot,
        ChatId chatId,
        string inviteLink
    ) =>
        await bot.SendRequest<InviteLinkResponse>(
            BotRequest.CreatePost("revokeChatInviteLink", new { chatId, inviteLink })
        );
}
