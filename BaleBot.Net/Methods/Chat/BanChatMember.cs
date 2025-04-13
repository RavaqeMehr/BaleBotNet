using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> BanChatMember(this BaleBotClient bot, string chatId, long userId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "banChatMember")
        {
            Content = JsonContent.Create(new { chat_id = chatId, user_id = userId })
        };

        return await bot.SendRequest<bool>(request);
    }

    public static async Task<bool> BanChatMember(
        this BaleBotClient bot,
        long chatId,
        long userId
    ) => await BanChatMember(bot, chatId.ToString(), userId);
}
