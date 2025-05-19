using BaleBotNet.Types;

namespace BaleBotNet.Methods;

public static partial class Methods
{
    public static async Task<InviteLinkResponse> CreateChatInviteLink(
        this BaleBotClient bot,
        ChatId chatId
    ) =>
        await bot.SendRequest<InviteLinkResponse>(
            BotRequest.CreatePost("createChatInviteLink", new { chatId })
        );
}
