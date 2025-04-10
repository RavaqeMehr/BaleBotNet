using System.Net.Http.Json;
using BaleBot.Net.Types;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<InviteLinkResult> CreateChatInviteLink(
        this BaleBotClient bot,
        string chatId
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "createChatInviteLink")
        {
            Content = JsonContent.Create(new { chat_id = chatId })
        };

        return await bot.SendRequest<InviteLinkResult>(request);
    }
}
