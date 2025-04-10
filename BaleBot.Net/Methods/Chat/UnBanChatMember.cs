using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> UnBanChatMember(
        this BaleBotClient bot,
        string chatId,
        long userId,
        bool onlyIfBanned
    )
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "unbanChatMember")
        {
            Content = JsonContent.Create(
                new
                {
                    chat_id = chatId,
                    user_id = userId,
                    only_if_banned = onlyIfBanned
                }
            )
        };

        return await bot.SendRequest<bool>(request);
    }
}
