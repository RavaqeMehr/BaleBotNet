using System.Net.Http.Json;

namespace BaleBot.Net.Methods;

public static partial class Methods
{
    public static async Task<bool> IsUserMemberOfChat(
        this BaleBotClient bot,
        string chatId,
        long userId
    )
    {
        if (!chatId.StartsWith('@'))
        {
            if (!long.TryParse(chatId, out _))
            {
                chatId = $"@{chatId}";
            }
        }

        var request = new HttpRequestMessage(HttpMethod.Post, "getChatMember")
        {
            Content = JsonContent.Create(new { chat_id = chatId, user_id = userId })
        };

        try
        {
            _ = await bot.SendRequest<object>(request);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static async Task<bool> IsUserMemberOfChat(
        this BaleBotClient bot,
        long chatId,
        long userId
    ) => await IsUserMemberOfChat(bot, chatId.ToString(), userId);
}
